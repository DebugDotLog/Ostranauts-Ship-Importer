using System.IO.Compression;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Ostranauts_Ship_Importer
{
    internal class Utils
    {
        private const int FirstIndex = 0;

        // Reads and serializes JSON into an object of type T (ship or saveInfo)
        public static T LoadJson<T>(string json)
        {
            return JsonSerializer.Deserialize<T[]>(json)[0];
        }
        // Swap the required JSON fields between the two objects, nulls unneeded arrays
        public static Ship SwapShipData(Ship importShip, Ship replaceShip, bool unharmed)
        {
            replaceShip.strName = importShip.strName;
            replaceShip.fWearAccrued = importShip.fWearAccrued;
            replaceShip.aItems = importShip.aItems;
            replaceShip.aRooms = importShip.aRooms;
            replaceShip.make = importShip.make;
            replaceShip.model = importShip.model;
            replaceShip.year = importShip.year;
            replaceShip.origin = importShip.origin;
            replaceShip.description = importShip.description;
            replaceShip.objSS.bBOLocked = false;
            replaceShip.aCOs = null;
            replaceShip.aShallowPSpecs = null;
            if (unharmed)
            {
                replaceShip.bPrefill = false;
            }

            return replaceShip;
        }
        // Finds the selected ship's JSON file in the save's zipfile, then calls LoadJson with that data.
        public static Ship ReadShipFromSave(string shipFileName, string saveFile)
        {
            using (ZipArchive zip = ZipFile.OpenRead(saveFile))
            {
                foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    if (entry.Name == shipFileName)
                    {
                        using (StreamReader sr = new(entry.Open()))
                            return (Utils.LoadJson<Ship>(sr.ReadToEnd().Trim()));
                    }
                }
            }
            return null;
        }
        // Copies the existing save to new folder and updates the selected ship file and the saveInfo JSONs 
        public static void SaveFiles(string saveFile, string shipName, Ship outShip)
        {
            // set up some file/folder names for future use
            string oldFolder = saveFile.Substring(FirstIndex, 1 + saveFile.LastIndexOf('\\'));
            string newFolder = saveFile.Substring(FirstIndex, saveFile.LastIndexOf('\\')) + @"_imported_ship\";
            string oldFileName = saveFile.Substring(1 + saveFile.LastIndexOf("\\"));
            string newFileName = oldFileName.Substring(FirstIndex, oldFileName.LastIndexOf('.')) + "_imported_ship.zip";

            // set up options for reserialization of JSON from strings
            var options = new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

            // Copy save data to new folder 
            CopyDir.Copy(oldFolder, newFolder);
            File.Move(newFolder + oldFileName, newFolder + newFileName);

            UpdateSaveInfo(newFolder, options);

            UpdateZippedFiles(newFolder, newFileName, shipName, outShip, options);
        }

        //Open, modify and save saveInfo changes (save name, save log, and time)
        public static void UpdateSaveInfo(string newFolder, JsonSerializerOptions options)
        {

            SaveInfo saveInfo = LoadJson<SaveInfo>(File.ReadAllText(newFolder + "saveInfo.json").Trim());

            saveInfo.strName += "_imported_ship";
            saveInfo.strSaveLog += "* " + DateTime.Now.ToString("M/d/yyyy h:mm:ss tt") + " Ship Imported!\n";
            saveInfo.realWorldTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            SaveInfo[] saveInfoArray = { saveInfo };
            string output = JsonSerializer.Serialize(saveInfoArray, options);
            File.WriteAllText(newFolder + "saveInfo.json", output);
        }

        // Opens the new save file's zip to replace the selected ship with the new data
        public static void UpdateZippedFiles(string newFolder, string newFileName, string shipName, Ship outShip, JsonSerializerOptions options)
        {
            using (ZipArchive zip = ZipFile.Open(newFolder + newFileName, ZipArchiveMode.Update))
            {

                foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    if (entry.Name == "saveInfo.json" || entry.Name == shipName)
                    {
                        entry.Delete();
                        break;
                    }
                }

                foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    if (entry.Name == shipName)
                    {
                        entry.Delete();
                        break;
                    }
                }

                ZipArchiveEntry shipEntry = zip.CreateEntry(@"ships\" + shipName);
                using (StreamWriter writer = new(shipEntry.Open()))
                {
                    Ship[] shipArray = [outShip];
                    writer.Write(JsonSerializer.Serialize(shipArray, options));
                }

                // Also replace saveInfo.json in the zip file (why!?)
                zip.CreateEntryFromFile(newFolder + "saveInfo.json", "saveInfo.json");
                zip.Dispose();
            }
        }
        // Creates a List of Shipnames to populate combobox
        public static List<string> GenerateShipList(string saveFile)
        {
            List<string> shipList = [];
            using (ZipArchive zip = ZipFile.OpenRead(saveFile))
            {
                foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    string ship = entry.FullName;
                    if (ship.StartsWith("ships/") && ship.EndsWith(".json"))
                    {
                        string shortShip = ship.Substring(6);
                        if (shortShip[1] == '-')
                        {
                            shortShip = shortShip.Replace(".json", "");
                            shipList.Add(shortShip);
                        }
                    }
                }
                return shipList;
            }
        }
    }

    // Taken from MSDN https://learn.microsoft.com/en-us/dotnet/api/system.io.directoryinfo?view=net-8.0
    class CopyDir
    {
        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new(sourceDirectory);
            DirectoryInfo diTarget = new(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
}