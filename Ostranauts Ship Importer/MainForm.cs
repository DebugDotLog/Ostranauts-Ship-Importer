using System.IO.Compression;


namespace Ostranauts_Ship_Importer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            unharmedCheckBox.Checked = true;
            replaceShipComboBox.Enabled = false;
            replaceButton.Enabled = false;
            readSaveButton.Enabled = false;
            successLabel.Hide();
        }

        private void ImportBrowseButton_Click(object sender, EventArgs e)
        {
            successLabel.Hide();

            OpenFileDialog fDialog = new()
            {
                Title = "Choose a JSON file to import",
                Filter = "JSON Files|*.json",
                InitialDirectory = @"%ProgramFiles(x86)%\Steam\steamapps\common\Ostranauts\Ostranauts_Data\StreamingAssets\data\ships\"
            };

            DialogResult result = fDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = fDialog.FileName;
                this.importText.Text = file;
            }
        }

        private void ReplaceBrowseButton_Click(object sender, EventArgs e)
        {
            successLabel.Hide();

            OpenFileDialog fDialog = new()
            {
                Title = "Choose a zip file from the save that will be modified",
                Filter = "ZIP Files|*.zip",
                InitialDirectory = @"%APPDATA%\..\LocalLow\Blue Bottle Games\OStranauts\Save\"
            };
            DialogResult result = fDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = fDialog.FileName;
                this.replaceText.Text = file;
                this.readSaveButton.Enabled = true;
            }
        }

        private void ReadSaveButton_Click(object sender, EventArgs e)
        {
            List<string> shipList = [];

            using (ZipArchive zip = ZipFile.OpenRead(this.replaceText.Text))
            {
                foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    string ship = entry.FullName;
                    if (ship.StartsWith("ships/") && ship.EndsWith(".json"))
                    {
                        string shortShip = ship.Substring(6);
                        shortShip = shortShip.Replace(".json", "");
                        shipList.Add(shortShip);
                    }
                }
            }

            this.replaceShipComboBox.DataSource = shipList;
            if (shipList != null)
            {
                this.replaceShipComboBox.Enabled = true;
                this.replaceButton.Enabled = true;
            }
        }

        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            string shipFileName = this.replaceShipComboBox.SelectedItem + ".json";

            Ship replaceShip = Utils.ReadShipFromSave(shipFileName, this.replaceText.Text);

            Ship importShip = Utils.LoadJson<Ship>(File.ReadAllText(this.importText.Text));
            Ship outShip = Utils.SwapShipData(importShip, replaceShip, this.unharmedCheckBox.Checked);

            Utils.SaveFiles(this.replaceText.Text, shipFileName, outShip);

            successLabel.Show();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
