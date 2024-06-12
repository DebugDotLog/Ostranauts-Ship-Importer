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
            if (shipList != null)
            {
                replaceShipComboBox.Enabled = true;
                replaceButton.Enabled = true;
                randomizeCheckBox.Enabled = true;
            }
        }

        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            string jsonExtension = ".json";
            string shipFileName = replaceShipComboBox.SelectedItem + jsonExtension;

            // Logic for ship randomizer option, overwrites shipFileName
            if (randomizeCheckBox.Checked)
            {
                var random = new Random();
                int i = random.Next(shipFileName.Length);
                shipFileName = replaceShipComboBox.Items[i].ToString() + jsonExtension;
                System.Diagnostics.Debug.WriteLine(shipFileName);
            }

            Ship replaceShip = Utils.ReadShipFromSave(shipFileName, replaceText.Text);

            Ship importShip = Utils.LoadJson<Ship>(File.ReadAllText(importText.Text));
            Ship outShip = Utils.SwapShipData(importShip, replaceShip, unharmedCheckBox.Checked);

            Utils.SaveFiles(replaceText.Text, shipFileName, outShip);

            successLabel.Show();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
