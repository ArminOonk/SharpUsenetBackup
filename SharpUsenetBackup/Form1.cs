using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SevenZip;
using System.Threading;
using yEnc;
using NntpClientLib;
using System.Text.RegularExpressions;
using System.Xml;

namespace SharpUsenetBackup
{
    public partial class MainForm : Form
    {
        //private string tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        private string tempDir = Path.Combine(@"D:\Temp\SharpUsenetBackupTemp", Path.GetRandomFileName());
        private string tempFile = "";

        private string sourceDir = @"D:\Temp\CompressTest";
        private string SevenZipPath = Directory.GetCurrentDirectory() + @"\7z.dll";

        private SevenZipCompressor compressor = new SevenZipCompressor();
        private bool cancleUpload = false;
        private Par2Wrapper par2;
        private yEncWrapper yEncW;

        //private List<string> messageId;
        private List<UsenetFile> fileList;

        private Configuration conf = new Configuration();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set Temp Files
            tempFile = "BackUp";
            tempDirBox.Text = tempDir;
            sourceDirBox.Text = sourceDir;
            nzbBox.Text = conf.NzbDir;

            // Set library path to 7Zip Dll
            SevenZipExtractor.SetLibraryPath(SevenZipPath);
            SevenZipCompressor.SetLibraryPath(SevenZipPath);

            // Check if we have features
            var features = SevenZipExtractor.CurrentLibraryFeatures;
            SetOutText(((uint)features).ToString("X6"));

            SetOutText(Encoding.Default.HeaderName);
            // Event handlers
            compressor.FileCompressionStarted += fileCompressStarted;
            compressor.CompressionFinished += CompressFinished;
            compressor.ZipEncryptionMethod = ZipEncryptionMethod.Aes256;
            compressor.EncryptHeaders = true;

            //Setup Par2
            par2 = new Par2Wrapper();
            par2.Par2Path = Directory.GetCurrentDirectory() + @"\par2.exe";

            // Setup yEnc
            yEncW = new yEncWrapper();

            //Set default block size
            volumeSizeBox.SelectedIndex = 3;

            // Disable the cancle button
            cancleButton.Enabled = false;

            //
            //messageId = new List<string>();
            fileList = new List<UsenetFile>();

            SetOutText("Conf Nzb File: " + conf.NzbDir);
            SetOutText("Conf Usenet Server: " + conf.UsenetServer);
            SetOutText("Conf Usenet User: " + conf.UsenetUser);
            SetOutText("Conf Usenet Password: " + conf.UsenetPassword);
            SetOutText("Conf Usenet Poster: " + conf.UsenetPoster);

            string timeString = String.Format("{0:MMddyy HHMMss}", DateTime.Now);
            SetOutText("DateTime: " + timeString);
        }

        /// <summary>
        /// Main Form is closed, delete the temp directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            conf.WriteConfiguration();
            try
            {
                Directory.Delete(tempDir, true);
            }
            catch (Exception ex)
            {
                SetOutText("Delete Exception: " + ex.Message);
            }
        }

        protected void fileCompressStarted(object obj, FileNameEventArgs ev)
        {
            SetOutText(String.Format("[{0}%] {1}", ev.PercentDone, ev.FileName));
            SetCompressProgress(ev.PercentDone);

            if (cancleUpload)
            {
                ev.Cancel = true;
                SetOutText("Upload cancled");
                SetCompressProgress(0);
            }
        }

        /// <summary>
        /// Compression is finished NOT the background task
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ev"></param>
        protected void CompressFinished(object obj, EventArgs ev)
        {
            SetOutText("fileCompressFinished");
            if (cancleUpload)
            {
                try
                {
                    cleanUpTemp();
                }
                catch (Exception ex)
                {
                    SetOutText("Delete Exception: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Start the upload
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uploadButton_Click(object sender, EventArgs e)
        {
            if (sourceDir == "")
                return;

            cancleUpload = false;
            // Check of de temp dir leeg is!
            cleanUpTemp();

            uploadButton.Enabled = false;
            cancleButton.Enabled = true;

            fileList.Clear();
            compressWorker.RunWorkerAsync();        
        }

        /// <summary>
        /// Set the source directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sourceDirButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "Select the directory that you want to use as the default.";
            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.SelectedPath = sourceDir;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                sourceDir = folderBrowserDialog1.SelectedPath;
                sourceDirBox.Text = sourceDir;
            }
        }

        private void nzbButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "Select the directory that you want to use as the default.";
            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.SelectedPath = sourceDir;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                conf.NzbDir = folderBrowserDialog1.SelectedPath;
                nzbBox.Text = conf.NzbDir;
            }
        }

        /// <summary>
        /// Select the temp directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tempDirButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "Select the directory that you want to use as the default.";
            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.SelectedPath = tempDir;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tempDir = folderBrowserDialog1.SelectedPath;
                tempDirBox.Text = tempDir;
            }
        }

        delegate void SetTextCallback(string text);
        /// <summary>
        /// Thread safe append to the output box
        /// </summary>
        /// <param name="text"></param>
        private void SetOutText(string text)
        {
            if (this.outputBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetOutText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.outputBox.AppendText(text + Environment.NewLine);
            }
        }

        delegate void SetCompressCallback(byte val);
        /// <summary>
        /// Thread safe update of the compress progressbar
        /// </summary>
        /// <param name="val"></param>
        private void SetCompressProgress(byte val)
        {
            if (this.compressBar.InvokeRequired)
            {
                SetCompressCallback d = new SetCompressCallback(SetCompressProgress);
                this.Invoke(d, new object[] { val });
            }
            else
            {
                this.compressBar.Value = val;
            }
        }

        delegate void SetSendCallback(byte val);
        /// <summary>
        /// Thread safe update of the compress progressbar
        /// </summary>
        /// <param name="val"></param>
        private void SetSendProgress(byte val)
        {
            if (this.sendingBar.InvokeRequired)
            {
                SetSendCallback d = new SetSendCallback(SetSendProgress);
                this.Invoke(d, new object[] { val });
            }
            else
            {
                this.sendingBar.Value = val;
            }
        }

        private void cancleButton_Click(object sender, EventArgs e)
        {
            cancleUpload = true;
        }

        /// <summary>
        /// Calculate the Volume Size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileSizeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (volumeSizeBox.Items[volumeSizeBox.SelectedIndex].ToString())
            {
                case "":
                    compressor.VolumeSize = 0 * 1024 * 1024; // 10 MegaByte per Volume MultiPart Test
                    break;

                case "10M":
                    compressor.VolumeSize = 10 * 1024 * 1024; // 10 MegaByte per Volume MultiPart Test
                    break;

                case "20M":
                    compressor.VolumeSize = 20 * 1024 * 1024; // 10 MegaByte per Volume MultiPart Test
                    break;

                case "30M":
                    compressor.VolumeSize = 30 * 1024 * 1024; // 10 MegaByte per Volume MultiPart Test
                    break;

                case "40M":
                    compressor.VolumeSize = 40 * 1024 * 1024; // 10 MegaByte per Volume MultiPart Test
                    break;

                case "50M":
                    compressor.VolumeSize = 50 * 1024 * 1024; // 10 MegaByte per Volume MultiPart Test
                    break;
            }

            par2.VolumeSize = compressor.VolumeSize;
            SetOutText("Volume Size: " + compressor.VolumeSize);
        }

        /// <summary>
        /// Starting compression
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void compressWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (password1Box.Text == password2Box.Text)
                {
                    if (password1Box.Text != "")
                    {
                        compressor.CompressDirectory(sourceDir, Path.Combine(tempDir, tempFile) + ".7z", password1Box.Text);
                    }
                    else
                    {
                        compressor.CompressDirectory(sourceDir, Path.Combine(tempDir, tempFile) + ".7z");
                    }
                }
                else
                {
                    MessageBox.Show("The passwords do not match", "Password Error", MessageBoxButtons.OK);
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "compressor.CompressDirectory", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Compression is done
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void compressWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetOutText("Done Compressing, starting par");
            
            SetOutText(par2.createPar2(tempDir, tempFile));

            sendWorker.RunWorkerAsync(); 

            // Done encoding
            uploadButton.Enabled = true;
            cancleButton.Enabled = false;
        }

        /// <summary>
        /// Clean up all temp files, make GUI ready for new run
        /// </summary>
        private void cleanUpTemp()
        {
            //Clean up files
            if (Directory.Exists(tempDir))
            {
                DirectoryInfo directory = new DirectoryInfo(tempDir);

                foreach (System.IO.FileInfo file in directory.GetFiles())
                    file.Delete();

                foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories())
                    subDirectory.Delete(true);

            }
            else
            {
                Directory.CreateDirectory(tempDir);
            }
            //Set GUI
            uploadButton.Enabled = true;
            cancleButton.Enabled = false;
        }

        private void postFile(string fileName, string subject, params string[] groups)
        {
            int fileSize = 0;
            if(File.Exists(fileName))
            {
                if (groups.Length == 0)
                {
                    MessageBox.Show("No newsgroups selected", "Error posting file", MessageBoxButtons.OK);
                    return ;
                }

                Stream myStream = null;
                string result = "";
                
                try
                {
                    if ((myStream = File.OpenRead(fileName)) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                            fileSize = (int)myStream.Length;
                            byte[] buffer = new byte[fileSize];
                            int count;                            // actual number of bytes read
                            int sum = 0;                          // total number of bytes read

                            // read until Read method returns 0 (end of the stream has been reached)
                            while ((count = myStream.Read(buffer, sum, fileSize - sum)) > 0)
                                sum += count;  // sum is a buffer offset for next reading

                            myStream.Close();

                            Encoding enc = Encoding.GetEncoding("Windows-1252");
                            result = enc.GetString(buffer);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Reading File", MessageBoxButtons.OK);
                }

                List<string> resultList = new List<string>(Regex.Split(result, "\r\n"));

                using (Rfc977NntpClientWithExtensions client = new Rfc977NntpClientWithExtensions())
                {
                    client.Connect(conf.UsenetServer);
                    client.AuthenticateUser(conf.UsenetUser, conf.UsenetPassword);

                    string newsgroup = groups[0];
                    for (int i = 1; i < groups.Length; i++)
                        newsgroup += "," + groups[i];

                    SetOutText("NewsGroups: " + newsgroup);

                    client.SelectNewsgroup(groups[0]);

                    ArticleHeadersDictionary headers = new ArticleHeadersDictionary();
                    headers.AddHeader("From", conf.UsenetPoster);
                    headers.AddHeader("Subject", subject);
                    headers.AddHeader("Newsgroups", newsgroup);
                    headers.AddHeader("Date", new NntpDateTime(DateTime.Now).ToString());

                    SetOutText("ResultList length: " + resultList.Count);
                    client.PostArticle(new ArticleHeadersDictionaryEnumerator(headers), resultList);

                    SetOutText("Done Sending file: " + client.LastNntpResponse);

                    string[] response = client.LastNntpResponse.Split(' ');
                    if (response[0] != "240")
                    {
                        MessageBox.Show("News server returned error: " + response[0], "Error posting file", MessageBoxButtons.OK);
                    }
                    else
                    {
                        char[] strip = { '<', '>' };
                        fileList.Last().Append(response[1].Trim(strip), fileSize);
                    }
                }
            }else{
                MessageBox.Show("Could not find file: " + fileName, "Error posting file", MessageBoxButtons.OK);
            }
        }
        
        // Per file encode, temp bestanden in een map plaatsen en deze versturen
        // Nog maar 1 background worker nodig
        private void sendWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] tempPaths = Directory.GetFiles(tempDir);
            string yEncDir = Path.Combine(tempDir, "yEnc");
            Directory.CreateDirectory(yEncDir);
            
            int cnt = 0;
            string prefix = Guid.NewGuid().ToString();
            string group = "alt.test.abcd";
            foreach (string t in tempPaths)
            {
                fileList.Add(new UsenetFile(prefix + Path.GetFileName(t), group, "anon@anon"));
                yEncW.ProcessFile(tempDir, t);

                string[] encPaths = Directory.GetFiles(yEncDir);
                int partnum = 1;
                int numparts = encPaths.Length;

                foreach (string f in encPaths)
                {
                    postFile(f, "\"" + Path.GetFileName(t)+ "\" yEnc " + "(" + partnum + "/" + numparts + ")", group);
                    File.Delete(f);
                    partnum++;
                }
                SetSendProgress((byte)((100 * cnt) / tempPaths.Length));
                cnt++;
            }

            NzbCreator nzb = new NzbCreator();
            nzb.Title = "Dit is de Titel";
            nzb.Tag = "Dit is de tag";
            nzb.Groups = group;
            nzb.StartFile();
            foreach (UsenetFile u in fileList)
                nzb.AppendFile(u);

            string nzbFile = Path.Combine(conf.NzbDir, "Backup " + Path.GetFileName(sourceDir) + " " + String.Format("{0:MMddyy HHMMss}", DateTime.Now) + ".nzb");
            SetOutText("nzbFile: " + nzbFile);
            nzb.SaveFile(nzbFile);
        }

        private void sendWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            sendingBar.Value = 100;
            SetOutText("Sending complete");
        }
    }
}
