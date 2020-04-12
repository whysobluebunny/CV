namespace Bombe
{
    partial class BombeApp
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BombeApp));
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.loadFile = new System.Windows.Forms.Button();
            this.runBombe = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxParams = new System.Windows.Forms.TextBox();
            this.labelParams = new System.Windows.Forms.Label();
            this.infoPicture = new System.Windows.Forms.PictureBox();
            this.solutions = new System.Windows.Forms.ListBox();
            this.labelSolution = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.infoPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(15, 72);
            this.textBoxStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(522, 549);
            this.textBoxStatus.TabIndex = 0;
            // 
            // loadFile
            // 
            this.loadFile.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadFile.Location = new System.Drawing.Point(543, 72);
            this.loadFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.loadFile.Name = "loadFile";
            this.loadFile.Size = new System.Drawing.Size(585, 68);
            this.loadFile.TabIndex = 1;
            this.loadFile.Text = "Browse File";
            this.loadFile.UseVisualStyleBackColor = true;
            this.loadFile.Click += new System.EventHandler(this.loadFile_Click);
            // 
            // runBombe
            // 
            this.runBombe.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.runBombe.Location = new System.Drawing.Point(543, 148);
            this.runBombe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.runBombe.Name = "runBombe";
            this.runBombe.Size = new System.Drawing.Size(585, 49);
            this.runBombe.TabIndex = 2;
            this.runBombe.Text = "Run";
            this.runBombe.UseVisualStyleBackColor = true;
            this.runBombe.Click += new System.EventHandler(this.runBombe_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStatus.Location = new System.Drawing.Point(163, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(200, 52);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "STATUS";
            // 
            // textBoxParams
            // 
            this.textBoxParams.Location = new System.Drawing.Point(543, 459);
            this.textBoxParams.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxParams.Multiline = true;
            this.textBoxParams.Name = "textBoxParams";
            this.textBoxParams.ReadOnly = true;
            this.textBoxParams.Size = new System.Drawing.Size(697, 162);
            this.textBoxParams.TabIndex = 4;
            // 
            // labelParams
            // 
            this.labelParams.AutoSize = true;
            this.labelParams.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelParams.Location = new System.Drawing.Point(538, 428);
            this.labelParams.Name = "labelParams";
            this.labelParams.Size = new System.Drawing.Size(194, 27);
            this.labelParams.TabIndex = 5;
            this.labelParams.Text = "Loaded Params";
            // 
            // infoPicture
            // 
            this.infoPicture.Image = ((System.Drawing.Image)(resources.GetObject("infoPicture.Image")));
            this.infoPicture.Location = new System.Drawing.Point(1136, 72);
            this.infoPicture.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.infoPicture.Name = "infoPicture";
            this.infoPicture.Size = new System.Drawing.Size(112, 124);
            this.infoPicture.TabIndex = 6;
            this.infoPicture.TabStop = false;
            this.infoPicture.Click += new System.EventHandler(this.Info_Click);
            // 
            // solutions
            // 
            this.solutions.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.solutions.FormattingEnabled = true;
            this.solutions.ItemHeight = 18;
            this.solutions.Location = new System.Drawing.Point(543, 258);
            this.solutions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.solutions.Name = "solutions";
            this.solutions.Size = new System.Drawing.Size(705, 166);
            this.solutions.TabIndex = 7;
            this.solutions.Click += new System.EventHandler(this.solutions_Click);
            // 
            // labelSolution
            // 
            this.labelSolution.AutoSize = true;
            this.labelSolution.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSolution.Location = new System.Drawing.Point(543, 217);
            this.labelSolution.Name = "labelSolution";
            this.labelSolution.Size = new System.Drawing.Size(404, 27);
            this.labelSolution.TabIndex = 8;
            this.labelSolution.Text = "You can select solution here";
            // 
            // BombeApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 634);
            this.Controls.Add(this.labelSolution);
            this.Controls.Add(this.solutions);
            this.Controls.Add(this.infoPicture);
            this.Controls.Add(this.labelParams);
            this.Controls.Add(this.textBoxParams);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.runBombe);
            this.Controls.Add(this.loadFile);
            this.Controls.Add(this.textBoxStatus);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1276, 690);
            this.MinimumSize = new System.Drawing.Size(1276, 690);
            this.Name = "BombeApp";
            this.Text = "Bombe";
            ((System.ComponentModel.ISupportInitialize)(this.infoPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Button loadFile;
        private System.Windows.Forms.Button runBombe;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox textBoxParams;
        private System.Windows.Forms.Label labelParams;
        private System.Windows.Forms.PictureBox infoPicture;
        private System.Windows.Forms.ListBox solutions;
        private System.Windows.Forms.Label labelSolution;
    }
}

