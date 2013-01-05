using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace SharpUsenetBackup
{
    class Configuration
    {
        public string NzbDir = string.Empty;

        public string UsenetServer = string.Empty;
        public string UsenetUser = string.Empty;
        public string UsenetPassword = string.Empty;
        public string UsenetPoster = "anon@anon";
        private XmlDocument xmlDoc;

        public Configuration()
        {
            ReadConfiguration();
        }

        public void ReadConfiguration(string fileName = "configuration.xml")
        {
            if (File.Exists(fileName))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(fileName);
                XmlElement root = doc.DocumentElement;

                //Directories
                XmlNodeList nodeDirectories = root.SelectNodes("/Configuration/Directories");
                foreach (XmlNode node in nodeDirectories)
                {
                    if (node["NZBDir"] != null)
                    {
                        NzbDir = node["NZBDir"].InnerText;
                    }
                }

                // Usenet Server
                XmlNodeList nodeUsenet = root.SelectNodes("/Configuration/Usenet");
                foreach (XmlNode node in nodeUsenet)
                {
                    if (node["UsenetServer"] != null)
                    {
                        UsenetServer = node["UsenetServer"].InnerText;
                    }

                    if (node["UsenetUser"] != null)
                    {
                        UsenetUser = node["UsenetUser"].InnerText;
                    }

                    if (node["UsenetPassword"] != null)
                    {
                        UsenetPassword = node["UsenetPassword"].InnerText;
                    }

                    if (node["UsenetPoster"] != null)
                    {
                        UsenetPoster = node["UsenetPoster"].InnerText;
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Could not load configuration file: " + fileName, "Error configuration file", MessageBoxButtons.OK);
            }
        }

        public void WriteConfiguration(string fileName = "configuration.xml")
        {
            xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("Configuration");
            xmlDoc.AppendChild(rootNode);

            writeDirectories(rootNode);
            writeUsenet(rootNode);

            xmlDoc.Save(fileName);
        }

        private void writeDirectories(XmlNode node)
        {
            XmlNode directoriesNode = xmlDoc.CreateElement("Directories");

            XmlNode nzbNode = xmlDoc.CreateElement("NZBDir");
            nzbNode.InnerText = NzbDir;

            directoriesNode.AppendChild(nzbNode);
            node.AppendChild(directoriesNode);
        }

        private void writeUsenet(XmlNode node)
        {
            XmlNode usenetNode = xmlDoc.CreateElement("Usenet");

            XmlNode serverNode = xmlDoc.CreateElement("UsenetServer");
            serverNode.InnerText = UsenetServer;
            usenetNode.AppendChild(serverNode);

            XmlNode userNode = xmlDoc.CreateElement("UsenetUser");
            userNode.InnerText = UsenetUser;
            usenetNode.AppendChild(userNode);

            XmlNode passwordNode = xmlDoc.CreateElement("UsenetPassword");
            passwordNode.InnerText = UsenetPassword;
            usenetNode.AppendChild(passwordNode);

            XmlNode UsenetPosterNode = xmlDoc.CreateElement("UsenetPoster");
            UsenetPosterNode.InnerText = UsenetPoster;
            usenetNode.AppendChild(UsenetPosterNode);

            node.AppendChild(usenetNode);
        }
    }
}
