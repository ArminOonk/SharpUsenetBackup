using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using yEnc;
using System.Windows.Forms;

namespace SharpUsenetBackup
{
    class yEncWrapper
    {
        public int SegmentSize = 1000000;
        private TextWriter logFile;
        
        public yEncWrapper()
        {
            try
            {
                logFile = new StreamWriter("yencLog.txt");
            }catch(Exception ex){
                MessageBox.Show(ex.Message, "Could not Open Log File", MessageBoxButtons.OK);
            }
            writeLog(DateTime.Now.ToString());
        }

        public int encodeByte(byte[] buffer, out byte[] output)
        {
            YEncEncoder encoder = new YEncEncoder();
            int bytesRead = buffer.Length;

            // Get the number of bytes for the number of bytes read
            int destSize = encoder.GetByteCount(buffer, 0, bytesRead, true);
            output = new byte[destSize];
            int bytesWritten = encoder.GetBytes(buffer, 0, bytesRead, output, 0, true);
            return bytesWritten;
        }

        public int decodeByte(byte[] buffer, out byte[] output)
        {
            YEncDecoder decoder = new YEncDecoder();
            int bytesRead = buffer.Length;

            // Get the number of bytes for the number of bytes read
            int destSize = decoder.GetByteCount(buffer, 0, bytesRead, true);
            output = new byte[destSize];
            int bytesWritten = decoder.GetBytes(buffer, 0, bytesRead, output, 0, true);
            return bytesWritten;
        }

        public void ProcessFile(string dir, string fileName)
        {
            // Memory buffer 
            byte[] original = new byte[SegmentSize];

            // Create yEnc temp dir
            string yEncDir = Path.Combine(dir, "yEnc");
            Directory.CreateDirectory(yEncDir);

            using (FileStream fsInput = File.OpenRead(fileName))
            {
                FileInfo f = new FileInfo(fileName);
                long fileSize = f.Length;
                long nrSegments = fileSize / SegmentSize;

                // Division ignores the remained. If there is a remainder increase the nrSegments with 1
                if (fileSize % SegmentSize != 0)
                    nrSegments++;

                writeLog("Files found: " + fileName + " File Size: " + fileSize.ToString() + " Nr of Segments: " + nrSegments);

                YEncEncoder encoder = new YEncEncoder();

                for (int i = 0; i < nrSegments; i++)
                {
                    // Create Output file
                    string segmentFileName = Path.Combine(yEncDir, (i + 1).ToString("D8") + ".ync");
                    FileStream fsOutput = new FileStream(segmentFileName, FileMode.Create, FileAccess.Write, FileShare.Write);

                    bool flush = false;

                    int bytesRead = fsInput.Read(original, 0, SegmentSize);

                    if (((i + 1) * SegmentSize) >= fileSize)
                        flush = true;

                    // Get the number of bytes for the number of bytes read
                    int destSize = encoder.GetByteCount(original, 0, bytesRead, flush);
                    byte[] destBatch = new byte[destSize];
                    int bytesWritten = encoder.GetBytes(original, 0, bytesRead, destBatch, 0, true);

                    string header = "";
                    string trailer = "";

                    if (nrSegments == 1)
                    {
                        // Single Part
                        // =ybegin line=128 size=123456 name=mybinary.dat
                        header = "=ybegin line=128 size=" + bytesRead + " name=" + Path.GetFileName(fileName) + Environment.NewLine;

                        // Trailer
                        trailer = Environment.NewLine + "=yend size=" + bytesRead + " crc32=" + BitConverter.ToString(encoder.CRCHash).Replace("-", "").ToLower();
                    }
                    else
                    {
                        //Header
                        header = "=ybegin part=" + (i + 1).ToString() + " line = 128 size=" + bytesRead + " name=" + Path.GetFileName(fileName) + Environment.NewLine;
                        header += "=ypart begin=" + ((i * SegmentSize) + 1) + " end=" + ((i * SegmentSize) + bytesRead) + Environment.NewLine;

                        // Trailer
                        trailer = Environment.NewLine + "=yend size=" + bytesRead + " pcrc32=" + BitConverter.ToString(encoder.CRCHash).Replace("-", "").ToLower();
                    }

                    writeLog(header);
                    writeLog(trailer);
                    //here is where we would write off the batch to a file.  Lets do that.
                    try
                    {
                        fsOutput.Write(Encoding.ASCII.GetBytes(header), 0, header.Length);
                        fsOutput.Write(destBatch, 0, bytesWritten);
                        fsOutput.Write(Encoding.ASCII.GetBytes(trailer), 0, trailer.Length);
                    }
                    finally
                    {
                        fsOutput.Close();
                    }
                }
            }

        }

        public void ProcessDirectory(string dir)
        {
            // Lijst met files
            string[] filePaths = Directory.GetFiles(dir);

            // Memory buffer 
            byte[] original = new byte[SegmentSize];

            // Create yEnc temp dir
            string yEncDir = Path.Combine(dir, "yEnc");
            Directory.CreateDirectory(yEncDir);

            foreach (string fileName in filePaths)
                ProcessFile(dir, fileName);
        }

        public void writeLog(string txt)
        {
            logFile.WriteLine(txt);
            logFile.Flush();
        }
    }
}
