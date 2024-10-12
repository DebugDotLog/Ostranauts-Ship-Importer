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
            randomizeCheckBox.Enabled = false;
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
                importText.Text = file;
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
                replaceText.Text = file;
                readSaveButton.Enabled = true;
            }
        }

        private void ReadSaveButton_Click(object sender, EventArgs e)
        {
            List<string> shipList = Utils.GenerateShipList(replaceText.Text);

            replaceShipComboBox.DataSource = shipList;
            if (shipList.Any())
            {
                replaceShipComboBox.Enabled = true;
                replaceButton.Enabled = true;
                randomizeCheckBox.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error reading save file:\n\n" + replaceText.Text + "\n\nUnrecognized Zip File Structure.", "Error Reading Save File!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            string shipFileName = replaceShipComboBox.SelectedItem + Utils.jsonExtension;

            // Logic for ship randomizer option, overwrites above
            if (randomizeCheckBox.Checked)
            {
                var random = new Random();
                int i = random.Next(shipFileName.Length);
                shipFileName = replaceShipComboBox.Items[i].ToString() + Utils.jsonExtension;
                System.Diagnostics.Debug.WriteLine(shipFileName);
            }

            Ship replaceShip = Utils.ReadShipFromSave(shipFileName, replaceText.Text);

            Ship? importShip = default(Ship);
            string importShipData;
            try
            {
                importShipData = File.ReadAllText(importText.Text);
            }
            catch
            {
                MessageBox.Show("Error reading:\n\n" + importText.Text + "\n\nThe file does not exist or could not be accessed.", "Error Reading Import Ship File!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            importShip = Utils.LoadJson<Ship>(importShipData);

            if (replaceShip == null || importShip == null)
                return;

            Ship outShip = Utils.SwapShipData(importShip, replaceShip, unharmedCheckBox.Checked);

            if (Utils.SaveFiles(replaceText.Text, shipFileName, outShip))
                successLabel.Show();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void randomizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (randomizeCheckBox.Checked)
                replaceShipComboBox.Enabled = false;
            else replaceShipComboBox.Enabled = true;

        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog fDialog = new()
            {
                Title = "Export Selected Ship File",
                Filter = "JSON Files|*.json",
                InitialDirectory = @"%ProgramFiles(x86)%\Steam\steamapps\common\Ostranauts\Ostranauts_Data\StreamingAssets\data\ships\",
                FileName = replaceShipComboBox.Text
            };

            DialogResult result = fDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string shipFileName = replaceShipComboBox.SelectedItem + Utils.jsonExtension;

                // Logic for ship randomizer option, overwrites above
                if (randomizeCheckBox.Checked)
                {
                    var random = new Random();
                    int i = random.Next(shipFileName.Length);
                    shipFileName = replaceShipComboBox.Items[i].ToString() + Utils.jsonExtension;
                    System.Diagnostics.Debug.WriteLine(shipFileName);
                }
                Ship exportShip = Utils.ReadShipFromSave(shipFileName, replaceText.Text);
                exportShip.strName = exportShip.strRegID;
                string jShip = Utils.SerializeShip(exportShip);

                File.WriteAllText(fDialog.FileName, jShip);
                successLabel.Show();
            }
        }
        private void replaceShipComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            successLabel.Hide();
        }
    }
}
