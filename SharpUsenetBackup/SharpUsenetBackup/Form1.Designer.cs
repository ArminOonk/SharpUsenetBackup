namespace SharpUsenetBackup
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sourceDirBox = new System.Windows.Forms.TextBox();
            this.tempDirBox = new System.Windows.Forms.TextBox();
            this.sourceDirButton = new System.Windows.Forms.Button();
            this.tempDirButton = new System.Windows.Forms.Button();
            this.uploadButton = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.compressBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.cancleButton = new System.Windows.Forms.Button();
            this.volumeSizeBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.compressWorker = new System.ComponentModel.BackgroundWorker();
            this.label5 = new System.Windows.Forms.Label();
            this.password1Box = new System.Windows.Forms.TextBox();
            this.password2Box = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.sendingBar = new System.Windows.Forms.ProgressBar();
            this.sendWorker = new System.ComponentModel.BackgroundWorker();
            this.nzbButton = new System.Windows.Forms.Button();
            this.nzbBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source Directory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Temp Directory";
            // 
            // sourceDirBox
            // 
            this.sourceDirBox.Location = new System.Drawing.Point(105, 6);
            this.sourceDirBox.Name = "sourceDirBox";
            this.sourceDirBox.Size = new System.Drawing.Size(235, 20);
            this.sourceDirBox.TabIndex = 2;
            // 
            // tempDirBox
            // 
            this.tempDirBox.Location = new System.Drawing.Point(105, 32);
            this.tempDirBox.Name = "tempDirBox";
            this.tempDirBox.Size = new System.Drawing.Size(235, 20);
            this.tempDirBox.TabIndex = 3;
            // 
            // sourceDirButton
            // 
            this.sourceDirButton.Location = new System.Drawing.Point(346, 3);
            this.sourceDirButton.Name = "sourceDirButton";
            this.sourceDirButton.Size = new System.Drawing.Size(75, 23);
            this.sourceDirButton.TabIndex = 4;
            this.sourceDirButton.Text = "Source";
            this.sourceDirButton.UseVisualStyleBackColor = true;
            this.sourceDirButton.Click += new System.EventHandler(this.sourceDirButton_Click);
            // 
            // tempDirButton
            // 
            this.tempDirButton.Location = new System.Drawing.Point(347, 28);
            this.tempDirButton.Name = "tempDirButton";
            this.tempDirButton.Size = new System.Drawing.Size(75, 23);
            this.tempDirButton.TabIndex = 5;
            this.tempDirButton.Text = "Temp";
            this.tempDirButton.UseVisualStyleBackColor = true;
            this.tempDirButton.Click += new System.EventHandler(this.tempDirButton_Click);
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(12, 194);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(75, 23);
            this.uploadButton.TabIndex = 6;
            this.uploadButton.Text = "Upload";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // outputBox
            // 
            this.outputBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.outputBox.Location = new System.Drawing.Point(13, 223);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputBox.Size = new System.Drawing.Size(704, 293);
            this.outputBox.TabIndex = 7;
            // 
            // compressBar
            // 
            this.compressBar.Location = new System.Drawing.Point(500, 3);
            this.compressBar.Name = "compressBar";
            this.compressBar.Size = new System.Drawing.Size(217, 23);
            this.compressBar.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(427, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Compressing";
            // 
            // cancleButton
            // 
            this.cancleButton.Location = new System.Drawing.Point(93, 193);
            this.cancleButton.Name = "cancleButton";
            this.cancleButton.Size = new System.Drawing.Size(75, 23);
            this.cancleButton.TabIndex = 10;
            this.cancleButton.Text = "Cancle";
            this.cancleButton.UseVisualStyleBackColor = true;
            this.cancleButton.Click += new System.EventHandler(this.cancleButton_Click);
            // 
            // volumeSizeBox
            // 
            this.volumeSizeBox.FormattingEnabled = true;
            this.volumeSizeBox.Items.AddRange(new object[] {
            "",
            "10M",
            "20M",
            "30M",
            "40M",
            "50M"});
            this.volumeSizeBox.Location = new System.Drawing.Point(105, 86);
            this.volumeSizeBox.Name = "volumeSizeBox";
            this.volumeSizeBox.Size = new System.Drawing.Size(121, 21);
            this.volumeSizeBox.TabIndex = 11;
            this.volumeSizeBox.SelectedIndexChanged += new System.EventHandler(this.fileSizeBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Volume Size";
            // 
            // compressWorker
            // 
            this.compressWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.compressWorker_DoWork);
            this.compressWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.compressWorker_RunWorkerCompleted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Password";
            // 
            // password1Box
            // 
            this.password1Box.Location = new System.Drawing.Point(105, 115);
            this.password1Box.Name = "password1Box";
            this.password1Box.PasswordChar = '*';
            this.password1Box.Size = new System.Drawing.Size(235, 20);
            this.password1Box.TabIndex = 14;
            // 
            // password2Box
            // 
            this.password2Box.Location = new System.Drawing.Point(105, 141);
            this.password2Box.Name = "password2Box";
            this.password2Box.PasswordChar = '*';
            this.password2Box.Size = new System.Drawing.Size(235, 20);
            this.password2Box.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Password (again)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(430, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Sending";
            // 
            // sendingBar
            // 
            this.sendingBar.Location = new System.Drawing.Point(500, 32);
            this.sendingBar.Name = "sendingBar";
            this.sendingBar.Size = new System.Drawing.Size(217, 23);
            this.sendingBar.TabIndex = 23;
            // 
            // sendWorker
            // 
            this.sendWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.sendWorker_DoWork);
            this.sendWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.sendWorker_RunWorkerCompleted);
            // 
            // nzbButton
            // 
            this.nzbButton.Location = new System.Drawing.Point(347, 54);
            this.nzbButton.Name = "nzbButton";
            this.nzbButton.Size = new System.Drawing.Size(75, 23);
            this.nzbButton.TabIndex = 28;
            this.nzbButton.Text = "NZB";
            this.nzbButton.UseVisualStyleBackColor = true;
            this.nzbButton.Click += new System.EventHandler(this.nzbButton_Click);
            // 
            // nzbBox
            // 
            this.nzbBox.Location = new System.Drawing.Point(105, 58);
            this.nzbBox.Name = "nzbBox";
            this.nzbBox.Size = new System.Drawing.Size(235, 20);
            this.nzbBox.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "NZB File";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 528);
            this.Controls.Add(this.nzbButton);
            this.Controls.Add(this.nzbBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.sendingBar);
            this.Controls.Add(this.password2Box);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.password1Box);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.volumeSizeBox);
            this.Controls.Add(this.cancleButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.compressBar);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.tempDirButton);
            this.Controls.Add(this.sourceDirButton);
            this.Controls.Add(this.tempDirBox);
            this.Controls.Add(this.sourceDirBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Sharp Usenet Backup";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sourceDirBox;
        private System.Windows.Forms.TextBox tempDirBox;
        private System.Windows.Forms.Button sourceDirButton;
        private System.Windows.Forms.Button tempDirButton;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.ProgressBar compressBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancleButton;
        private System.Windows.Forms.ComboBox volumeSizeBox;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker compressWorker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox password1Box;
        private System.Windows.Forms.TextBox password2Box;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ProgressBar sendingBar;
        private System.ComponentModel.BackgroundWorker sendWorker;
        private System.Windows.Forms.Button nzbButton;
        private System.Windows.Forms.TextBox nzbBox;
        private System.Windows.Forms.Label label9;
    }
}

