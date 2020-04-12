namespace Bombe
{
    partial class StartingMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartingMenu));
            this.labelHeader = new System.Windows.Forms.Label();
            this.showInfo = new System.Windows.Forms.PictureBox();
            this.loadFile = new System.Windows.Forms.Button();
            this.newConfig = new System.Windows.Forms.Button();
            this.openEnigma = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.showInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Courier New", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHeader.Location = new System.Drawing.Point(290, 9);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(533, 67);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Bombe Emulator";
            // 
            // showInfo
            // 
            this.showInfo.Image = ((System.Drawing.Image)(resources.GetObject("showInfo.Image")));
            this.showInfo.Location = new System.Drawing.Point(12, 121);
            this.showInfo.Name = "showInfo";
            this.showInfo.Size = new System.Drawing.Size(100, 99);
            this.showInfo.TabIndex = 7;
            this.showInfo.TabStop = false;
            this.showInfo.Click += new System.EventHandler(this.ShowInfo_Click);
            // 
            // loadFile
            // 
            this.loadFile.Font = new System.Drawing.Font("Courier New", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadFile.Location = new System.Drawing.Point(150, 121);
            this.loadFile.Name = "loadFile";
            this.loadFile.Size = new System.Drawing.Size(856, 99);
            this.loadFile.TabIndex = 8;
            this.loadFile.Text = "Work With Existing Config File";
            this.loadFile.UseVisualStyleBackColor = true;
            this.loadFile.Click += new System.EventHandler(this.loadFile_Click);
            // 
            // newConfig
            // 
            this.newConfig.Font = new System.Drawing.Font("Courier New", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newConfig.Location = new System.Drawing.Point(150, 226);
            this.newConfig.Name = "newConfig";
            this.newConfig.Size = new System.Drawing.Size(856, 99);
            this.newConfig.TabIndex = 9;
            this.newConfig.Text = "Make New Config";
            this.newConfig.UseVisualStyleBackColor = true;
            this.newConfig.Click += new System.EventHandler(this.newConfig_Click);
            // 
            // openEnigma
            // 
            this.openEnigma.Font = new System.Drawing.Font("Courier New", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.openEnigma.Location = new System.Drawing.Point(150, 331);
            this.openEnigma.Name = "openEnigma";
            this.openEnigma.Size = new System.Drawing.Size(856, 99);
            this.openEnigma.TabIndex = 10;
            this.openEnigma.Text = "Enigma";
            this.openEnigma.UseVisualStyleBackColor = true;
            this.openEnigma.Click += new System.EventHandler(this.openEnigma_Click);
            // 
            // StartingMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 673);
            this.Controls.Add(this.openEnigma);
            this.Controls.Add(this.newConfig);
            this.Controls.Add(this.loadFile);
            this.Controls.Add(this.showInfo);
            this.Controls.Add(this.labelHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1135, 720);
            this.MinimumSize = new System.Drawing.Size(1135, 720);
            this.Name = "StartingMenu";
            this.Text = "StartingMenu";
            ((System.ComponentModel.ISupportInitialize)(this.showInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.PictureBox showInfo;
        private System.Windows.Forms.Button loadFile;
        private System.Windows.Forms.Button newConfig;
        private System.Windows.Forms.Button openEnigma;
    }
}