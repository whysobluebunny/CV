namespace Bombe
{
    partial class NewConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewConfig));
            this.rotor1 = new System.Windows.Forms.ComboBox();
            this.labelRotors = new System.Windows.Forms.Label();
            this.rotor2 = new System.Windows.Forms.ComboBox();
            this.rotor3 = new System.Windows.Forms.ComboBox();
            this.reflectorType = new System.Windows.Forms.ComboBox();
            this.labelRefType = new System.Windows.Forms.Label();
            this.labelCurrentEntry = new System.Windows.Forms.Label();
            this.currentEntry = new System.Windows.Forms.ComboBox();
            this.labelInputLetter = new System.Windows.Forms.Label();
            this.inputLetter = new System.Windows.Forms.ComboBox();
            this.labelMapList = new System.Windows.Forms.Label();
            this.MapEntryList = new System.Windows.Forms.ListBox();
            this.stepsAheadOfKey = new System.Windows.Forms.TextBox();
            this.leftChar = new System.Windows.Forms.TextBox();
            this.rightChar = new System.Windows.Forms.TextBox();
            this.labelStepsAK = new System.Windows.Forms.Label();
            this.labelLeftChar = new System.Windows.Forms.Label();
            this.labelRightChar = new System.Windows.Forms.Label();
            this.addME = new System.Windows.Forms.Button();
            this.removeSelected = new System.Windows.Forms.Button();
            this.enableDiagonalBoard = new System.Windows.Forms.CheckBox();
            this.saveAndSerialize = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openBombe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rotor1
            // 
            this.rotor1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rotor1.FormattingEnabled = true;
            this.rotor1.Items.AddRange(new object[] {
            "I",
            "II",
            "III",
            "IV",
            "V",
            "VI",
            "VII",
            "VIII",
            "Beta",
            "Gamma"});
            this.rotor1.Location = new System.Drawing.Point(14, 40);
            this.rotor1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rotor1.Name = "rotor1";
            this.rotor1.Size = new System.Drawing.Size(136, 28);
            this.rotor1.TabIndex = 0;
            this.rotor1.SelectedIndexChanged += new System.EventHandler(this.rotor1_SelectedIndexChanged);
            // 
            // labelRotors
            // 
            this.labelRotors.AutoSize = true;
            this.labelRotors.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRotors.Location = new System.Drawing.Point(10, 11);
            this.labelRotors.Name = "labelRotors";
            this.labelRotors.Size = new System.Drawing.Size(465, 23);
            this.labelRotors.TabIndex = 5;
            this.labelRotors.Text = "Choose rotors (Order is important):";
            // 
            // rotor2
            // 
            this.rotor2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rotor2.FormattingEnabled = true;
            this.rotor2.Items.AddRange(new object[] {
            "I",
            "II",
            "III",
            "IV",
            "V",
            "VI",
            "VII",
            "VIII",
            "Beta",
            "Gamma"});
            this.rotor2.Location = new System.Drawing.Point(156, 40);
            this.rotor2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rotor2.Name = "rotor2";
            this.rotor2.Size = new System.Drawing.Size(136, 28);
            this.rotor2.TabIndex = 6;
            this.rotor2.SelectedIndexChanged += new System.EventHandler(this.rotor2_SelectedIndexChanged);
            // 
            // rotor3
            // 
            this.rotor3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rotor3.FormattingEnabled = true;
            this.rotor3.Items.AddRange(new object[] {
            "I",
            "II",
            "III",
            "IV",
            "V",
            "VI",
            "VII",
            "VIII",
            "Beta",
            "Gamma"});
            this.rotor3.Location = new System.Drawing.Point(299, 40);
            this.rotor3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rotor3.Name = "rotor3";
            this.rotor3.Size = new System.Drawing.Size(136, 28);
            this.rotor3.TabIndex = 7;
            this.rotor3.SelectedIndexChanged += new System.EventHandler(this.rotor3_SelectedIndexChanged);
            // 
            // reflectorType
            // 
            this.reflectorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reflectorType.FormattingEnabled = true;
            this.reflectorType.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "B_Thin",
            "C_Thin"});
            this.reflectorType.Location = new System.Drawing.Point(14, 102);
            this.reflectorType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reflectorType.Name = "reflectorType";
            this.reflectorType.Size = new System.Drawing.Size(136, 28);
            this.reflectorType.TabIndex = 8;
            // 
            // labelRefType
            // 
            this.labelRefType.AutoSize = true;
            this.labelRefType.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRefType.Location = new System.Drawing.Point(10, 74);
            this.labelRefType.Name = "labelRefType";
            this.labelRefType.Size = new System.Drawing.Size(296, 23);
            this.labelRefType.TabIndex = 9;
            this.labelRefType.Text = "Select reflector type:";
            // 
            // labelCurrentEntry
            // 
            this.labelCurrentEntry.AutoSize = true;
            this.labelCurrentEntry.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCurrentEntry.Location = new System.Drawing.Point(9, 136);
            this.labelCurrentEntry.Name = "labelCurrentEntry";
            this.labelCurrentEntry.Size = new System.Drawing.Size(283, 23);
            this.labelCurrentEntry.TabIndex = 11;
            this.labelCurrentEntry.Text = "Choose current entry:";
            // 
            // currentEntry
            // 
            this.currentEntry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.currentEntry.FormattingEnabled = true;
            this.currentEntry.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.currentEntry.Location = new System.Drawing.Point(14, 165);
            this.currentEntry.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.currentEntry.Name = "currentEntry";
            this.currentEntry.Size = new System.Drawing.Size(136, 28);
            this.currentEntry.TabIndex = 12;
            this.currentEntry.SelectedIndexChanged += new System.EventHandler(this.currentEntry_SelectedIndexChanged);
            // 
            // labelInputLetter
            // 
            this.labelInputLetter.AutoSize = true;
            this.labelInputLetter.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInputLetter.Location = new System.Drawing.Point(9, 199);
            this.labelInputLetter.Name = "labelInputLetter";
            this.labelInputLetter.Size = new System.Drawing.Size(179, 23);
            this.labelInputLetter.TabIndex = 13;
            this.labelInputLetter.Text = "Input letter:";
            // 
            // inputLetter
            // 
            this.inputLetter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputLetter.FormattingEnabled = true;
            this.inputLetter.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.inputLetter.Location = new System.Drawing.Point(14, 228);
            this.inputLetter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inputLetter.Name = "inputLetter";
            this.inputLetter.Size = new System.Drawing.Size(136, 28);
            this.inputLetter.TabIndex = 14;
            this.inputLetter.SelectedIndexChanged += new System.EventHandler(this.inputLetter_SelectedIndexChanged);
            // 
            // labelMapList
            // 
            this.labelMapList.AutoSize = true;
            this.labelMapList.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMapList.Location = new System.Drawing.Point(9, 261);
            this.labelMapList.Name = "labelMapList";
            this.labelMapList.Size = new System.Drawing.Size(413, 23);
            this.labelMapList.TabIndex = 16;
            this.labelMapList.Text = "Create an array of map entries:";
            // 
            // MapEntryList
            // 
            this.MapEntryList.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MapEntryList.FormattingEnabled = true;
            this.MapEntryList.ItemHeight = 18;
            this.MapEntryList.Location = new System.Drawing.Point(456, 40);
            this.MapEntryList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MapEntryList.Name = "MapEntryList";
            this.MapEntryList.Size = new System.Drawing.Size(356, 436);
            this.MapEntryList.TabIndex = 17;
            // 
            // stepsAheadOfKey
            // 
            this.stepsAheadOfKey.AcceptsReturn = true;
            this.stepsAheadOfKey.Location = new System.Drawing.Point(14, 290);
            this.stepsAheadOfKey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stepsAheadOfKey.Name = "stepsAheadOfKey";
            this.stepsAheadOfKey.Size = new System.Drawing.Size(112, 26);
            this.stepsAheadOfKey.TabIndex = 18;
            this.stepsAheadOfKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StepsAheadOfKey_KeyUp);
            // 
            // leftChar
            // 
            this.leftChar.AcceptsReturn = true;
            this.leftChar.Location = new System.Drawing.Point(15, 325);
            this.leftChar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.leftChar.Name = "leftChar";
            this.leftChar.Size = new System.Drawing.Size(112, 26);
            this.leftChar.TabIndex = 19;
            this.leftChar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LeftChar_KeyUp);
            // 
            // rightChar
            // 
            this.rightChar.AcceptsReturn = true;
            this.rightChar.Location = new System.Drawing.Point(14, 360);
            this.rightChar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rightChar.Name = "rightChar";
            this.rightChar.Size = new System.Drawing.Size(112, 26);
            this.rightChar.TabIndex = 20;
            this.rightChar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RightChar_KeyUp);
            // 
            // labelStepsAK
            // 
            this.labelStepsAK.AutoSize = true;
            this.labelStepsAK.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStepsAK.Location = new System.Drawing.Point(133, 292);
            this.labelStepsAK.Name = "labelStepsAK";
            this.labelStepsAK.Size = new System.Drawing.Size(244, 23);
            this.labelStepsAK.TabIndex = 21;
            this.labelStepsAK.Text = "Steps ahead of key";
            // 
            // labelLeftChar
            // 
            this.labelLeftChar.AutoSize = true;
            this.labelLeftChar.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLeftChar.Location = new System.Drawing.Point(134, 328);
            this.labelLeftChar.Name = "labelLeftChar";
            this.labelLeftChar.Size = new System.Drawing.Size(192, 23);
            this.labelLeftChar.TabIndex = 22;
            this.labelLeftChar.Text = "Left character";
            // 
            // labelRightChar
            // 
            this.labelRightChar.AutoSize = true;
            this.labelRightChar.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRightChar.Location = new System.Drawing.Point(133, 361);
            this.labelRightChar.Name = "labelRightChar";
            this.labelRightChar.Size = new System.Drawing.Size(205, 23);
            this.labelRightChar.TabIndex = 23;
            this.labelRightChar.Text = "Right character";
            // 
            // addME
            // 
            this.addME.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addME.Location = new System.Drawing.Point(14, 395);
            this.addME.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addME.Name = "addME";
            this.addME.Size = new System.Drawing.Size(288, 42);
            this.addME.TabIndex = 24;
            this.addME.Text = "Add MapEntry";
            this.addME.UseVisualStyleBackColor = true;
            this.addME.Click += new System.EventHandler(this.addME_Click);
            // 
            // removeSelected
            // 
            this.removeSelected.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.removeSelected.Location = new System.Drawing.Point(15, 442);
            this.removeSelected.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.removeSelected.Name = "removeSelected";
            this.removeSelected.Size = new System.Drawing.Size(287, 42);
            this.removeSelected.TabIndex = 25;
            this.removeSelected.Text = "Remove Element";
            this.removeSelected.UseVisualStyleBackColor = true;
            this.removeSelected.Click += new System.EventHandler(this.removeSelected_Click);
            // 
            // enableDiagonalBoard
            // 
            this.enableDiagonalBoard.AutoSize = true;
            this.enableDiagonalBoard.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.enableDiagonalBoard.Location = new System.Drawing.Point(176, 102);
            this.enableDiagonalBoard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.enableDiagonalBoard.MaximumSize = new System.Drawing.Size(260, 30);
            this.enableDiagonalBoard.MinimumSize = new System.Drawing.Size(260, 30);
            this.enableDiagonalBoard.Name = "enableDiagonalBoard";
            this.enableDiagonalBoard.Size = new System.Drawing.Size(260, 30);
            this.enableDiagonalBoard.TabIndex = 26;
            this.enableDiagonalBoard.Text = "Enable diagonal board\r\n";
            this.enableDiagonalBoard.UseVisualStyleBackColor = true;
            // 
            // saveAndSerialize
            // 
            this.saveAndSerialize.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveAndSerialize.Location = new System.Drawing.Point(15, 494);
            this.saveAndSerialize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveAndSerialize.Name = "saveAndSerialize";
            this.saveAndSerialize.Size = new System.Drawing.Size(394, 42);
            this.saveAndSerialize.TabIndex = 27;
            this.saveAndSerialize.Text = "Save file";
            this.saveAndSerialize.UseVisualStyleBackColor = true;
            this.saveAndSerialize.Click += new System.EventHandler(this.saveAndSerialize_Click);
            // 
            // openBombe
            // 
            this.openBombe.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.openBombe.Location = new System.Drawing.Point(418, 494);
            this.openBombe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.openBombe.Name = "openBombe";
            this.openBombe.Size = new System.Drawing.Size(394, 42);
            this.openBombe.TabIndex = 28;
            this.openBombe.Text = "Open Bombe";
            this.openBombe.UseVisualStyleBackColor = true;
            this.openBombe.Click += new System.EventHandler(this.openBombe_Click);
            // 
            // NewConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 551);
            this.Controls.Add(this.openBombe);
            this.Controls.Add(this.saveAndSerialize);
            this.Controls.Add(this.enableDiagonalBoard);
            this.Controls.Add(this.removeSelected);
            this.Controls.Add(this.addME);
            this.Controls.Add(this.labelRightChar);
            this.Controls.Add(this.labelLeftChar);
            this.Controls.Add(this.labelStepsAK);
            this.Controls.Add(this.rightChar);
            this.Controls.Add(this.leftChar);
            this.Controls.Add(this.stepsAheadOfKey);
            this.Controls.Add(this.MapEntryList);
            this.Controls.Add(this.labelMapList);
            this.Controls.Add(this.inputLetter);
            this.Controls.Add(this.labelInputLetter);
            this.Controls.Add(this.currentEntry);
            this.Controls.Add(this.labelCurrentEntry);
            this.Controls.Add(this.labelRefType);
            this.Controls.Add(this.reflectorType);
            this.Controls.Add(this.rotor3);
            this.Controls.Add(this.rotor2);
            this.Controls.Add(this.labelRotors);
            this.Controls.Add(this.rotor1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(844, 607);
            this.MinimumSize = new System.Drawing.Size(844, 607);
            this.Name = "NewConfig";
            this.Text = "NewConfig";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox rotor1;
        private System.Windows.Forms.Label labelRotors;
        private System.Windows.Forms.ComboBox rotor2;
        private System.Windows.Forms.ComboBox rotor3;
        private System.Windows.Forms.ComboBox reflectorType;
        private System.Windows.Forms.Label labelRefType;
        private System.Windows.Forms.Label labelCurrentEntry;
        private System.Windows.Forms.ComboBox currentEntry;
        private System.Windows.Forms.Label labelInputLetter;
        private System.Windows.Forms.ComboBox inputLetter;
        private System.Windows.Forms.Label labelMapList;
        private System.Windows.Forms.ListBox MapEntryList;
        private System.Windows.Forms.TextBox stepsAheadOfKey;
        private System.Windows.Forms.TextBox leftChar;
        private System.Windows.Forms.TextBox rightChar;
        private System.Windows.Forms.Label labelStepsAK;
        private System.Windows.Forms.Label labelLeftChar;
        private System.Windows.Forms.Label labelRightChar;
        private System.Windows.Forms.Button addME;
        private System.Windows.Forms.Button removeSelected;
        private System.Windows.Forms.CheckBox enableDiagonalBoard;
        private System.Windows.Forms.Button saveAndSerialize;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button openBombe;
    }
}