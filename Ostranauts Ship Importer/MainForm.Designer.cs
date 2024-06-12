namespace Ostranauts_Ship_Importer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            importGroupBox = new GroupBox();
            unharmedCheckBox = new CheckBox();
            importTextLabel = new Label();
            importBrowseButton = new Button();
            importText = new TextBox();
            replaceGroupBox = new GroupBox();
            randomizeCheckBox = new CheckBox();
            replaceShipCombolabel = new Label();
            readSaveButton = new Button();
            replaceShipComboBox = new ComboBox();
            replaceTextLabel = new Label();
            replaceBrowseButton = new Button();
            replaceText = new TextBox();
            replaceButton = new Button();
            quitButton = new Button();
            successLabel = new Label();
            importGroupBox.SuspendLayout();
            replaceGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // importGroupBox
            // 
            importGroupBox.Controls.Add(unharmedCheckBox);
            importGroupBox.Controls.Add(importTextLabel);
            importGroupBox.Controls.Add(importBrowseButton);
            importGroupBox.Controls.Add(importText);
            importGroupBox.Location = new Point(14, 14);
            importGroupBox.Margin = new Padding(4, 3, 4, 3);
            importGroupBox.Name = "importGroupBox";
            importGroupBox.Padding = new Padding(4, 3, 4, 3);
            importGroupBox.Size = new Size(574, 106);
            importGroupBox.TabIndex = 3;
            importGroupBox.TabStop = false;
            importGroupBox.Text = "Importing";
            // 
            // unharmedCheckBox
            // 
            unharmedCheckBox.AutoSize = true;
            unharmedCheckBox.Location = new Point(12, 78);
            unharmedCheckBox.Margin = new Padding(4, 3, 4, 3);
            unharmedCheckBox.Name = "unharmedCheckBox";
            unharmedCheckBox.Size = new Size(252, 19);
            unharmedCheckBox.TabIndex = 6;
            unharmedCheckBox.Text = "Import ship without signs of wear and tear.";
            unharmedCheckBox.UseVisualStyleBackColor = true;
            // 
            // importTextLabel
            // 
            importTextLabel.AutoSize = true;
            importTextLabel.Location = new Point(8, 29);
            importTextLabel.Margin = new Padding(4, 0, 4, 0);
            importTextLabel.Name = "importTextLabel";
            importTextLabel.Size = new Size(158, 15);
            importTextLabel.TabIndex = 5;
            importTextLabel.Text = "Select the ship file to import:";
            // 
            // importBrowseButton
            // 
            importBrowseButton.Location = new Point(474, 45);
            importBrowseButton.Margin = new Padding(4, 3, 4, 3);
            importBrowseButton.Name = "importBrowseButton";
            importBrowseButton.Size = new Size(88, 27);
            importBrowseButton.TabIndex = 4;
            importBrowseButton.Text = "Browse";
            importBrowseButton.UseVisualStyleBackColor = true;
            importBrowseButton.Click += ImportBrowseButton_Click;
            // 
            // importText
            // 
            importText.Location = new Point(12, 47);
            importText.Margin = new Padding(4, 3, 4, 3);
            importText.Name = "importText";
            importText.Size = new Size(454, 23);
            importText.TabIndex = 3;
            // 
            // replaceGroupBox
            // 
            replaceGroupBox.Controls.Add(randomizeCheckBox);
            replaceGroupBox.Controls.Add(replaceShipCombolabel);
            replaceGroupBox.Controls.Add(readSaveButton);
            replaceGroupBox.Controls.Add(replaceShipComboBox);
            replaceGroupBox.Controls.Add(replaceTextLabel);
            replaceGroupBox.Controls.Add(replaceBrowseButton);
            replaceGroupBox.Controls.Add(replaceText);
            replaceGroupBox.Location = new Point(14, 127);
            replaceGroupBox.Margin = new Padding(4, 3, 4, 3);
            replaceGroupBox.Name = "replaceGroupBox";
            replaceGroupBox.Padding = new Padding(4, 3, 4, 3);
            replaceGroupBox.Size = new Size(574, 140);
            replaceGroupBox.TabIndex = 7;
            replaceGroupBox.TabStop = false;
            replaceGroupBox.Text = "Replacing";
            // 
            // randomizeCheckBox
            // 
            randomizeCheckBox.AutoSize = true;
            randomizeCheckBox.Location = new Point(322, 95);
            randomizeCheckBox.Name = "randomizeCheckBox";
            randomizeCheckBox.Size = new Size(91, 19);
            randomizeCheckBox.TabIndex = 11;
            randomizeCheckBox.Text = "Surprise Me!";
            randomizeCheckBox.UseVisualStyleBackColor = true;
            // 
            // replaceShipCombolabel
            // 
            replaceShipCombolabel.AutoSize = true;
            replaceShipCombolabel.Location = new Point(103, 74);
            replaceShipCombolabel.Margin = new Padding(4, 0, 4, 0);
            replaceShipCombolabel.Name = "replaceShipCombolabel";
            replaceShipCombolabel.Size = new Size(141, 15);
            replaceShipCombolabel.TabIndex = 7;
            replaceShipCombolabel.Text = "Select the ship to replace:";
            // 
            // readSaveButton
            // 
            readSaveButton.Location = new Point(12, 91);
            readSaveButton.Margin = new Padding(4, 3, 4, 3);
            readSaveButton.Name = "readSaveButton";
            readSaveButton.Size = new Size(88, 27);
            readSaveButton.TabIndex = 10;
            readSaveButton.Text = "Read Save";
            readSaveButton.UseVisualStyleBackColor = true;
            readSaveButton.Click += ReadSaveButton_Click;
            // 
            // replaceShipComboBox
            // 
            replaceShipComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            replaceShipComboBox.FormattingEnabled = true;
            replaceShipComboBox.Location = new Point(106, 93);
            replaceShipComboBox.Margin = new Padding(4, 3, 4, 3);
            replaceShipComboBox.Name = "replaceShipComboBox";
            replaceShipComboBox.Size = new Size(209, 23);
            replaceShipComboBox.TabIndex = 6;
            // 
            // replaceTextLabel
            // 
            replaceTextLabel.AutoSize = true;
            replaceTextLabel.Location = new Point(8, 29);
            replaceTextLabel.Margin = new Padding(4, 0, 4, 0);
            replaceTextLabel.Name = "replaceTextLabel";
            replaceTextLabel.Size = new Size(213, 15);
            replaceTextLabel.TabIndex = 5;
            replaceTextLabel.Text = "Select the zip of the save file to modify:";
            // 
            // replaceBrowseButton
            // 
            replaceBrowseButton.Location = new Point(474, 45);
            replaceBrowseButton.Margin = new Padding(4, 3, 4, 3);
            replaceBrowseButton.Name = "replaceBrowseButton";
            replaceBrowseButton.Size = new Size(88, 27);
            replaceBrowseButton.TabIndex = 4;
            replaceBrowseButton.Text = "Browse";
            replaceBrowseButton.UseVisualStyleBackColor = true;
            replaceBrowseButton.Click += ReplaceBrowseButton_Click;
            // 
            // replaceText
            // 
            replaceText.Location = new Point(12, 47);
            replaceText.Margin = new Padding(4, 3, 4, 3);
            replaceText.Name = "replaceText";
            replaceText.Size = new Size(454, 23);
            replaceText.TabIndex = 3;
            // 
            // replaceButton
            // 
            replaceButton.Location = new Point(26, 273);
            replaceButton.Margin = new Padding(4, 3, 4, 3);
            replaceButton.Name = "replaceButton";
            replaceButton.Size = new Size(88, 27);
            replaceButton.TabIndex = 8;
            replaceButton.Text = "Replace";
            replaceButton.UseVisualStyleBackColor = true;
            replaceButton.Click += ReplaceButton_Click;
            // 
            // quitButton
            // 
            quitButton.Location = new Point(488, 273);
            quitButton.Margin = new Padding(4, 3, 4, 3);
            quitButton.Name = "quitButton";
            quitButton.Size = new Size(88, 27);
            quitButton.TabIndex = 9;
            quitButton.Text = "Quit";
            quitButton.UseVisualStyleBackColor = true;
            quitButton.Click += closeButton_Click;
            // 
            // successLabel
            // 
            successLabel.AutoSize = true;
            successLabel.ForeColor = Color.ForestGreen;
            successLabel.Location = new Point(122, 279);
            successLabel.Margin = new Padding(4, 0, 4, 0);
            successLabel.Name = "successLabel";
            successLabel.Size = new Size(51, 15);
            successLabel.TabIndex = 10;
            successLabel.Text = "Success!";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(606, 315);
            Controls.Add(successLabel);
            Controls.Add(quitButton);
            Controls.Add(replaceButton);
            Controls.Add(replaceGroupBox);
            Controls.Add(importGroupBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "Ostranauts Ship Replacer";
            Load += MainForm_Load;
            importGroupBox.ResumeLayout(false);
            importGroupBox.PerformLayout();
            replaceGroupBox.ResumeLayout(false);
            replaceGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.GroupBox importGroupBox;
        private System.Windows.Forms.Label importTextLabel;
        private System.Windows.Forms.Button importBrowseButton;
        private System.Windows.Forms.TextBox importText;
        private System.Windows.Forms.CheckBox unharmedCheckBox;
        private System.Windows.Forms.GroupBox replaceGroupBox;
        private System.Windows.Forms.Label replaceTextLabel;
        private System.Windows.Forms.Button replaceBrowseButton;
        private System.Windows.Forms.TextBox replaceText;
        private System.Windows.Forms.Label replaceShipCombolabel;
        private System.Windows.Forms.ComboBox replaceShipComboBox;
        private System.Windows.Forms.Button replaceButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button readSaveButton;
        private System.Windows.Forms.Label successLabel;
        private CheckBox randomizeCheckBox;
    }
}