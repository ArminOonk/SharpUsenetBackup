using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace SharpUsenetBackup
{
    class Fingerprint
    {
        private StreamReader fingerReadFile;
        private StreamWriter fingerWriteFile;

        private string fingerprintDir = string.Empty;
        private string fingerprintFileName = ".fingerprint";
        private string fingerprintPath = ".fingerprint";
        private HashAlgorithm hashAlgorithm;
        private bool readFingerprint = false;

        public Dictionary<string, string> fingerprint = new Dictionary<string, string>();
        public Dictionary<string, string> fingerprintStored = new Dictionary<string, string>();
        
        public Fingerprint(string workDir)
        {
            if (!Directory.Exists(workDir))
                throw new ArgumentException("Work directory does not excist");

            fingerprintDir = workDir;

            fingerprintPath = Path.Combine(fingerprintDir, fingerprintFileName);
            
            // Hash
            try
            {
                hashAlgorithm = new SHA256CryptoServiceProvider();
            }
            catch (PlatformNotSupportedException)
            {
                // Fall back to the managed version if the CSP
                // is not supported on this platform.
                hashAlgorithm = new SHA256Managed();
            }

            // if fingerprint exist load is else make it
            if (!File.Exists(fingerprintPath))
            {
                CreateFingerprint();
                SaveFingerprint();
            }
            else
            {
                LoadFingerprint();
            }
        }

        public List<string> Difference()
        {
            List<string> diff = new List<string>();

            CreateFingerprint();

            if (!readFingerprint)
                LoadFingerprint();

            foreach (KeyValuePair<string, string> pair in fingerprint)
            {
                if (fingerprintStored.ContainsKey(pair.Key))
                {
                    if (pair.Value != fingerprintStored[pair.Key])
                        diff.Add(Path.Combine(fingerprintDir, pair.Key));
                }
                else
                {
                    diff.Add(Path.Combine(fingerprintDir, pair.Key));
                }
            }

            return diff;
        }
        /// <summary>
        /// Create a fingerprint dataset from a directory
        /// </summary>
        public void CreateFingerprint()
        {
            fingerprint.Clear();
            DirSearch(fingerprintDir);
        }

        private void DirSearch(string sDir)
        {
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    if(f != fingerprintPath)
                        fingerprint.Add(f.Remove(0,fingerprintDir.Length+1), HashFile(f, hashAlgorithm));
                }

                foreach (string d in Directory.GetDirectories(sDir))
                {
                    DirSearch(d);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
        /// <summary>
        /// Loads the file into memory
        /// </summary>
        public void LoadFingerprint()
        {
            fingerprintStored.Clear();
            readFingerprint = true;
            using(fingerReadFile = new StreamReader(fingerprintPath))
            {
                string line;
                while ((line = fingerReadFile.ReadLine()) != null)
                {
                    string[] keyVal = line.Split('|');
                    if (keyVal.Length == 2)
                    {
                        fingerprintStored.Add(keyVal[0], keyVal[1]);
                    }

                }

            }
        }

        /// <summary>
        /// Writes the memory to the file
        /// </summary>
        public void SaveFingerprint()
        {
            using (fingerWriteFile = new StreamWriter(fingerprintPath))
            {
                foreach (KeyValuePair<string, string> pair in fingerprint)
                {
                    fingerWriteFile.WriteLine(pair.Key + "|" + pair.Value);
                }
            }
        }

        /// <summary>
        /// Performs a Hash operation on the supplied file.
        /// </summary>
        /// <param name="filename">
        /// The filename to be hashed.
        /// </param>
        /// <returns>
        /// Selected Hash value associated with the file
        /// </returns>
        public static string HashFile(string filename, HashAlgorithm hashAlgorithm)
        {
            if (!File.Exists(filename))
            {
                throw new ArgumentException(filename + " must exist", "filename");
            }

            string hashedValue = string.Empty;
            byte[] hashedData = null;

            // Create the stream
            using (FileStream fs = File.Open(filename, FileMode.Open, FileAccess.Read))
            {
                hashedData = hashAlgorithm.ComputeHash(fs);
            }

            //loop through each byte in the returned byte array
            foreach (byte b in hashedData)
            {
                //convert each byte and append
                hashedValue += String.Format("{0,2:x2}", b);
            }

            //return the hashed value
            return hashedValue;
        }
    }
}
