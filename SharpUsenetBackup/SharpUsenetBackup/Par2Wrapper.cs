using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;


namespace SharpUsenetBackup
{
    class Par2Wrapper
    {
        private string _par2Path = "";
        public string Par2Path
        {
            get { return _par2Path; }
            set
            {
                if (File.Exists(value))
                {
                    _par2Path = value;
                }
                else
                {
                    MessageBox.Show("Par2 exe not found!", "Par2 Error", MessageBoxButtons.OK);
                }
            }
        }

        private int _volumeSize = 0;
        public int VolumeSize
        {
            set
            {
                if (value >= 0)
                    _volumeSize = value;
                else
                    _volumeSize = 0;
            }

            get { return _volumeSize; }
        }

        private Process par2;
        public Par2Wrapper()
        {
            par2 = new Process();
        }

        public string createPar2(string workDir, string fileName)
        {
            par2.StartInfo.Arguments = " create -s" + _volumeSize.ToString() + " -r20 " + workDir + @"\" + fileName + ".par2 " + workDir + @"\*.7z*";
            par2.StartInfo.FileName = _par2Path;
            par2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            par2.StartInfo.UseShellExecute = false;
            par2.StartInfo.RedirectStandardOutput = true;
            par2.StartInfo.CreateNoWindow = true;
            par2.Exited += processCreatePar2Exited;

            par2.Start();

            return par2.StartInfo.FileName + Environment.NewLine + par2.StartInfo.Arguments + Environment.NewLine + par2.StandardOutput.ReadToEnd();
        }

        void processCreatePar2Exited(object sender, EventArgs a)
        {
            MessageBox.Show("Par2 Complete", "Par2 Complete", MessageBoxButtons.OK);
        }
    }
}
