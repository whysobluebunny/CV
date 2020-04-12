namespace Bombe
{
    partial class EnigmaApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnigmaApp));
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.input = new System.Windows.Forms.TextBox();
            this.output = new System.Windows.Forms.TextBox();
            this.rotorLab1 = new System.Windows.Forms.Label();
            this.rotorLab2 = new System.Windows.Forms.Label();
            this.rotorLab3 = new System.Windows.Forms.Label();
            this.plugboardSettings = new System.Windows.Forms.ListBox();
            this.refresh = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.labelWheels = new System.Windows.Forms.Label();
            this.labelReflector = new System.Windows.Forms.Label();
            this.rotor1 = new System.Windows.Forms.ComboBox();
            this.rotor2 = new System.Windows.Forms.ComboBox();
            this.rotor3 = new System.Windows.Forms.ComboBox();
            this.refType = new System.Windows.Forms.ComboBox();
            this.plgElem1 = new System.Windows.Forms.TextBox();
            this.plgElem2 = new System.Windows.Forms.TextBox();
            this.alphabet = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(36, 12);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(21, 22);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(87, 12);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(21, 22);
            this.numericUpDown2.TabIndex = 1;
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(138, 12);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(21, 22);
            this.numericUpDown3.TabIndex = 2;
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(7, 40);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(302, 22);
            this.input.TabIndex = 3;
            this.input.TextChanged += new System.EventHandler(this.input_TextChanged);
            this.input.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Input_KeyUp);
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(7, 69);
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(302, 22);
            this.output.TabIndex = 4;
            // 
            // rotorLab1
            // 
            this.rotorLab1.AutoSize = true;
            this.rotorLab1.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotorLab1.Location = new System.Drawing.Point(13, 14);
            this.rotorLab1.Name = "rotorLab1";
            this.rotorLab1.Size = new System.Drawing.Size(19, 20);
            this.rotorLab1.TabIndex = 6;
            this.rotorLab1.Text = "Z";
            // 
            // rotorLab2
            // 
            this.rotorLab2.AutoSize = true;
            this.rotorLab2.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rotorLab2.Location = new System.Drawing.Point(64, 14);
            this.rotorLab2.Name = "rotorLab2";
            this.rotorLab2.Size = new System.Drawing.Size(19, 20);
            this.rotorLab2.TabIndex = 7;
            this.rotorLab2.Text = "Z";
            // 
            // rotorLab3
            // 
            this.rotorLab3.AutoSize = true;
            this.rotorLab3.Font = new System.Drawing.Font("Courier New", 10.2F);
            this.rotorLab3.Location = new System.Drawing.Point(115, 14);
            this.rotorLab3.Name = "rotorLab3";
            this.rotorLab3.Size = new System.Drawing.Size(19, 20);
            this.rotorLab3.TabIndex = 8;
            this.rotorLab3.Text = "Z";
            // 
            // plugboardSettings
            // 
            this.plugboardSettings.FormattingEnabled = true;
            this.plugboardSettings.ItemHeight = 16;
            this.plugboardSettings.Location = new System.Drawing.Point(315, 41);
            this.plugboardSettings.Name = "plugboardSettings";
            this.plugboardSettings.Size = new System.Drawing.Size(72, 292);
            this.plugboardSettings.TabIndex = 9;
            // 
            // refresh
            // 
            this.refresh.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.refresh.Location = new System.Drawing.Point(168, 12);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(219, 23);
            this.refresh.TabIndex = 10;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(315, 339);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(72, 23);
            this.remove.TabIndex = 11;
            this.remove.Text = "Delete";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // labelWheels
            // 
            this.labelWheels.AutoSize = true;
            this.labelWheels.Font = new System.Drawing.Font("Courier New", 10.2F);
            this.labelWheels.Location = new System.Drawing.Point(3, 94);
            this.labelWheels.Name = "labelWheels";
            this.labelWheels.Size = new System.Drawing.Size(129, 20);
            this.labelWheels.TabIndex = 12;
            this.labelWheels.Text = "Wheel types:";
            // 
            // labelReflector
            // 
            this.labelReflector.AutoSize = true;
            this.labelReflector.Font = new System.Drawing.Font("Courier New", 10.2F);
            this.labelReflector.Location = new System.Drawing.Point(3, 131);
            this.labelReflector.Name = "labelReflector";
            this.labelReflector.Size = new System.Drawing.Size(159, 20);
            this.labelReflector.TabIndex = 13;
            this.labelReflector.Text = "Reflector type:";
            // 
            // rotor1
            // 
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
            this.rotor1.Location = new System.Drawing.Point(168, 94);
            this.rotor1.Name = "rotor1";
            this.rotor1.Size = new System.Drawing.Size(43, 24);
            this.rotor1.TabIndex = 14;
            this.rotor1.SelectedIndexChanged += new System.EventHandler(this.rotor1_SelectedIndexChanged);
            // 
            // rotor2
            // 
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
            this.rotor2.Location = new System.Drawing.Point(217, 93);
            this.rotor2.Name = "rotor2";
            this.rotor2.Size = new System.Drawing.Size(43, 24);
            this.rotor2.TabIndex = 15;
            this.rotor2.SelectedIndexChanged += new System.EventHandler(this.rotor2_SelectedIndexChanged);
            // 
            // rotor3
            // 
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
            this.rotor3.Location = new System.Drawing.Point(266, 94);
            this.rotor3.Name = "rotor3";
            this.rotor3.Size = new System.Drawing.Size(43, 24);
            this.rotor3.TabIndex = 16;
            this.rotor3.SelectedIndexChanged += new System.EventHandler(this.rotor3_SelectedIndexChanged);
            // 
            // refType
            // 
            this.refType.FormattingEnabled = true;
            this.refType.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "B_Thin",
            "C_Thin"});
            this.refType.Location = new System.Drawing.Point(185, 130);
            this.refType.Name = "refType";
            this.refType.Size = new System.Drawing.Size(75, 24);
            this.refType.TabIndex = 17;
            // 
            // plgElem1
            // 
            this.plgElem1.Location = new System.Drawing.Point(7, 155);
            this.plgElem1.Name = "plgElem1";
            this.plgElem1.Size = new System.Drawing.Size(50, 22);
            this.plgElem1.TabIndex = 18;
            this.plgElem1.TextChanged += new System.EventHandler(this.plgElem1_TextChanged);
            // 
            // plgElem2
            // 
            this.plgElem2.Location = new System.Drawing.Point(68, 155);
            this.plgElem2.Name = "plgElem2";
            this.plgElem2.Size = new System.Drawing.Size(50, 22);
            this.plgElem2.TabIndex = 19;
            this.plgElem2.TextChanged += new System.EventHandler(this.plgElem2_TextChanged);
            // 
            // alphabet
            // 
            this.alphabet.AutoSize = true;
            this.alphabet.Location = new System.Drawing.Point(4, 180);
            this.alphabet.Name = "alphabet";
            this.alphabet.Size = new System.Drawing.Size(82, 85);
            this.alphabet.TabIndex = 20;
            this.alphabet.Text = "A B C D E F\r\nG H I J K L \r\nM N O P Q \r\nR S T U V \r\nW X Y Z";
            this.alphabet.Click += new System.EventHandler(this.alphabet_Click);
            // 
            // EnigmaApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 378);
            this.Controls.Add(this.alphabet);
            this.Controls.Add(this.plgElem2);
            this.Controls.Add(this.plgElem1);
            this.Controls.Add(this.refType);
            this.Controls.Add(this.rotor3);
            this.Controls.Add(this.rotor2);
            this.Controls.Add(this.rotor1);
            this.Controls.Add(this.labelReflector);
            this.Controls.Add(this.labelWheels);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.plugboardSettings);
            this.Controls.Add(this.rotorLab3);
            this.Controls.Add(this.rotorLab2);
            this.Controls.Add(this.rotorLab1);
            this.Controls.Add(this.output);
            this.Controls.Add(this.input);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(421, 425);
            this.MinimumSize = new System.Drawing.Size(421, 425);
            this.Name = "EnigmaApp";
            this.Text = "EnigmaApp";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Label rotorLab1;
        private System.Windows.Forms.Label rotorLab2;
        private System.Windows.Forms.Label rotorLab3;
        private System.Windows.Forms.ListBox plugboardSettings;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Label labelWheels;
        private System.Windows.Forms.Label labelReflector;
        private System.Windows.Forms.ComboBox rotor1;
        private System.Windows.Forms.ComboBox rotor2;
        private System.Windows.Forms.ComboBox rotor3;
        private System.Windows.Forms.ComboBox refType;
        private System.Windows.Forms.TextBox plgElem1;
        private System.Windows.Forms.TextBox plgElem2;
        private System.Windows.Forms.Label alphabet;
    }
}