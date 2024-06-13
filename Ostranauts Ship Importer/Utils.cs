using System.IO.Compression;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Ostranauts_Ship_Importer
{
    /// <summary>
    /// Contains utility methods for Ostranauts Ship Importer
    /// </summary>
    internal class Utils
    {
        public static string saveInfoFile = "saveInfo.json";
        public static string jsonExtension = ".json";
        private const int FirstIndex = 0;

        /// <summary>
        /// Reads <paramref name="json"/> and deserializes into a(n) <typeparamref name="T"/> object
        /// </summary>
        /// <typeparam name="T">JSON object (ship or saveInfo)</typeparam>
        /// <param name="json">JSON text to serialize</param>
        /// <returns> Deserialized <typeparamref name="T"/> object</returns>
        public static T? LoadJson<T>(string json)
        {
            json = json.Trim();
            try
            {
                return JsonSerializer.Deserialize<T[]>(json)[0];
            }
            catch
            {
                MessageBox.Show("A specified file does not does not contain readable JSON data.", "Error Parsing JSON Data!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T?);
            }
        }

        /// <summary>
        /// Swap the required JSON fields between the two objects, nulls unneeded arrays
        /// </summary>
        /// <param name="importShip">JSON object Ship to import</param>
        /// <param name="replaceShip">JSON object Ship to replace</param>
        /// <param name="unharmed">No wear and tear flag</param>
        /// <returns>JSON object Ship with required fields replaced</returns>
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

        /// <summary>
        /// Finds the selected ship's JSON file in the save's zipfile, then calls LoadJson with that data.
        /// </summary>
        /// <param name="shipFileName">The JSON ship filename to read</param>
        /// <param name="saveFile">The filename of the save containing <paramref name="shipFileName"/></param>
        /// <returns></returns>
        public static Ship ReadShipFromSave(string shipFileName, string saveFile)
        {
            using (ZipArchive zip = ZipFile.OpenRead(saveFile))
            {
                foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    if (entry.Name == shipFileName)
                    {
                        using (StreamReader sr = new(entry.Open()))
                            return (Utils.LoadJson<Ship>(sr.ReadToEnd()));
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Copies the existing <paramref name="saveFile"/> to a new folder and updates it with modified <paramref name="outShip"/> and the saveInfo JSON files 
        /// </summary>
        /// <param name="saveFile">Full name of save file</param>
        /// <param name="shipName">Full name of ship file</param>
        /// <param name="outShip">Final modified JSON Ship object</param>
        /// <returns>True if completed without errors.</returns>
        public static bool SaveFiles(string saveFile, string shipName, Ship outShip)
        {
            // set up some file/folder names for future use
            string oldFolder = saveFile.Substring(FirstIndex, 1 + saveFile.LastIndexOf('\\'));
            string newFolder = saveFile.Substring(FirstIndex, saveFile.LastIndexOf('\\')) + @"_imported_ship\";
            string oldFileName = saveFile.Substring(1 + saveFile.LastIndexOf("\\"));
            string newFileName = oldFileName.Substring(FirstIndex, oldFileName.LastIndexOf('.')) + "_imported_ship.zip";

            // set up options for reserialization of JSON from strings
            var options = new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

            // If the new folder doesn't already exist, copy save data to new folder 
            if (Directory.Exists(newFolder))
            {
                MessageBox.Show("Error creating new save Folder:\n\n" + newFolder + "\n\nThe folder may already exist, or write permission was denied.", "Error Creating Folder!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            CopyDir.Copy(oldFolder, newFolder);

            File.Move(newFolder + oldFileName, newFolder + newFileName);

            UpdateSaveInfo(newFolder, options);

            UpdateZippedFiles(newFolder, newFileName, shipName, outShip, options);

            return true;
        }

        /// <summary>
        /// Open, modify and save saveInfo changes (save name, save log, and time) in <paramref name="newFolder"/>.
        /// </summary>
        /// <param name="newFolder">Name of new save folder</param>
        /// <param name="options">Options info for JSON serialation</param>
        public static void UpdateSaveInfo(string newFolder, JsonSerializerOptions options)
        {
            string? saveInfoData = null;
            string fullInfoFilename = newFolder + saveInfoFile;
            SaveInfo? saveInfo = null;

            try
            {
                saveInfoData = File.ReadAllText(fullInfoFilename);
            }
            catch
            {
                MessageBox.Show("Error opening file:\n\n" + fullInfoFilename + "\n\nThe file does not exist or could not be accessed.", "Error Reading Save File!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (saveInfoData != null)
            {
                saveInfo = LoadJson<SaveInfo>(saveInfoData);
            }

            if (saveInfo == null)
                return;

            saveInfo.strName += "_imported_ship";
            saveInfo.strSaveLog += "* " + DateTime.Now.ToString("M/d/yyyy h:mm:ss tt") + " Ship Imported!\n";
            saveInfo.realWorldTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            SaveInfo[] saveInfoArray = { saveInfo };
            string output = JsonSerializer.Serialize(saveInfoArray, options);
            File.WriteAllText(newFolder + saveInfoFile, output);
        }

        /// <summary>
        /// Opens the new save file's zip to replace the selected ship with the new data
        /// </summary>
        /// <param name="newFolder">Name of new save folder</param>
        /// <param name="newFileName">Name of the new save file</param>
        /// <param name="shipName">Filename of the modified ship</param>
        /// <param name="outShip">The modified Ship data</param>
        /// <param name="options">Options for JSON Serialization</param>
        public static void UpdateZippedFiles(string newFolder, string newFileName, string shipName, Ship outShip, JsonSerializerOptions options)
        {
            using (ZipArchive zip = ZipFile.Open(newFolder + newFileName, ZipArchiveMode.Update))
            {

                foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    if (entry.Name == saveInfoFile || entry.Name == shipName)
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
                zip.CreateEntryFromFile(newFolder + saveInfoFile, saveInfoFile);
            }
        }

        /// <summary>
        /// Creates a List of Shipnames read from <paramref name="saveFile"/> to populate combobox
        /// </summary>
        /// <param name="saveFile">Full name of existing save file.</param>
        /// <returns></returns>
        public static List<string> GenerateShipList(string saveFile)
        {
            List<string>? shipList = new();
            using (ZipArchive zip = ZipFile.OpenRead(saveFile))
            {
                foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    string ship = entry.FullName;
                    if (ship.StartsWith("ships/") && ship.EndsWith(jsonExtension))
                    {
                        string shortShip = ship.Substring(6);
                        if (shortShip[1] == '-')
                        {
                            shortShip = shortShip.Replace(jsonExtension, "");
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