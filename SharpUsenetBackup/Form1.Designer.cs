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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.usenetServerBox = new System.Windows.Forms.TextBox();
            this.usenetUserBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.usenetPassBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.usenetPosterBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.newgroupsAddButton = new System.Windows.Forms.Button();
            this.newsgroupsRemoveButton = new System.Windows.Forms.Button();
            this.newsgroupsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.uploadButton.Location = new System.Drawing.Point(15, 287);
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
            this.outputBox.Location = new System.Drawing.Point(13, 315);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputBox.Size = new System.Drawing.Size(959, 253);
            this.outputBox.TabIndex = 7;
            // 
            // compressBar
            // 
            this.compressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.compressBar.Location = new System.Drawing.Point(755, 3);
            this.compressBar.Name = "compressBar";
            this.compressBar.Size = new System.Drawing.Size(217, 23);
            this.compressBar.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(682, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Compressing";
            // 
            // cancleButton
            // 
            this.cancleButton.Location = new System.Drawing.Point(96, 286);
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
            this.volumeSizeBox.Location = new System.Drawing.Point(100, 19);
            this.volumeSizeBox.Name = "volumeSizeBox";
            this.volumeSizeBox.Size = new System.Drawing.Size(110, 21);
            this.volumeSizeBox.TabIndex = 11;
            this.volumeSizeBox.SelectedIndexChanged += new System.EventHandler(this.fileSizeBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 27);
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
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Password";
            // 
            // password1Box
            // 
            this.password1Box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.password1Box.Location = new System.Drawing.Point(100, 48);
            this.password1Box.Name = "password1Box";
            this.password1Box.PasswordChar = '*';
            this.password1Box.Size = new System.Drawing.Size(194, 20);
            this.password1Box.TabIndex = 14;
            // 
            // password2Box
            // 
            this.password2Box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.password2Box.Location = new System.Drawing.Point(100, 74);
            this.password2Box.Name = "password2Box";
            this.password2Box.PasswordChar = '*';
            this.password2Box.Size = new System.Drawing.Size(194, 20);
            this.password2Box.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Password (again)";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(703, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Sending";
            // 
            // sendingBar
            // 
            this.sendingBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sendingBar.Location = new System.Drawing.Point(755, 32);
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.usenetPosterBox);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.testButton);
            this.groupBox1.Controls.Add(this.saveButton);
            this.groupBox1.Controls.Add(this.usenetPassBox);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.usenetUserBox);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.usenetServerBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(642, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 151);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usenet";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Server";
            // 
            // usenetServerBox
            // 
            this.usenetServerBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.usenetServerBox.Location = new System.Drawing.Point(52, 20);
            this.usenetServerBox.Name = "usenetServerBox";
            this.usenetServerBox.Size = new System.Drawing.Size(272, 20);
            this.usenetServerBox.TabIndex = 1;
            // 
            // usenetUserBox
            // 
            this.usenetUserBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.usenetUserBox.Location = new System.Drawing.Point(51, 46);
            this.usenetUserBox.Name = "usenetUserBox";
            this.usenetUserBox.Size = new System.Drawing.Size(272, 20);
            this.usenetUserBox.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "User";
            // 
            // usenetPassBox
            // 
            this.usenetPassBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.usenetPassBox.Location = new System.Drawing.Point(51, 72);
            this.usenetPassBox.Name = "usenetPassBox";
            this.usenetPassBox.PasswordChar = '*';
            this.usenetPassBox.Size = new System.Drawing.Size(272, 20);
            this.usenetPassBox.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Pass";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(248, 122);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // testButton
            // 
            this.testButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.testButton.Location = new System.Drawing.Point(167, 122);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 23);
            this.testButton.TabIndex = 7;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // usenetPosterBox
            // 
            this.usenetPosterBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.usenetPosterBox.Location = new System.Drawing.Point(51, 98);
            this.usenetPosterBox.Name = "usenetPosterBox";
            this.usenetPosterBox.Size = new System.Drawing.Size(272, 20);
            this.usenetPosterBox.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 101);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Poster";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.volumeSizeBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.password1Box);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.password2Box);
            this.groupBox2.Location = new System.Drawing.Point(16, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 105);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "7Zip Settings";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.newsgroupsCheckedListBox);
            this.groupBox3.Controls.Add(this.newsgroupsRemoveButton);
            this.groupBox3.Controls.Add(this.newgroupsAddButton);
            this.groupBox3.Location = new System.Drawing.Point(322, 93);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(300, 192);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Newsgroups";
            // 
            // newgroupsAddButton
            // 
            this.newgroupsAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newgroupsAddButton.Location = new System.Drawing.Point(219, 163);
            this.newgroupsAddButton.Name = "newgroupsAddButton";
            this.newgroupsAddButton.Size = new System.Drawing.Size(75, 23);
            this.newgroupsAddButton.TabIndex = 1;
            this.newgroupsAddButton.Text = "Add";
            this.newgroupsAddButton.UseVisualStyleBackColor = true;
            // 
            // newsgroupsRemoveButton
            // 
            this.newsgroupsRemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newsgroupsRemoveButton.Location = new System.Drawing.Point(7, 163);
            this.newsgroupsRemoveButton.Name = "newsgroupsRemoveButton";
            this.newsgroupsRemoveButton.Size = new System.Drawing.Size(75, 23);
            this.newsgroupsRemoveButton.TabIndex = 2;
            this.newsgroupsRemoveButton.Text = "Remove";
            this.newsgroupsRemoveButton.UseVisualStyleBackColor = true;
            this.newsgroupsRemoveButton.Click += new System.EventHandler(this.newsgroupsRemoveButton_Click);
            // 
            // newsgroupsCheckedListBox
            // 
            this.newsgroupsCheckedListBox.FormattingEnabled = true;
            this.newsgroupsCheckedListBox.Items.AddRange(new object[] {
            "alt.test.abcd",
            "alt.test",
            "alt.binaries.backup"});
            this.newsgroupsCheckedListBox.Location = new System.Drawing.Point(7, 20);
            this.newsgroupsCheckedListBox.Name = "newsgroupsCheckedListBox";
            this.newsgroupsCheckedListBox.Size = new System.Drawing.Size(287, 139);
            this.newsgroupsCheckedListBox.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 580);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nzbButton);
            this.Controls.Add(this.nzbBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.sendingBar);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox usenetPassBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox usenetUserBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox usenetServerBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox usenetPosterBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button newsgroupsRemoveButton;
        private System.Windows.Forms.Button newgroupsAddButton;
        private System.Windows.Forms.CheckedListBox newsgroupsCheckedListBox;
    }
}

