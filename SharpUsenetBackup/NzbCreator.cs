using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SharpUsenetBackup
{
    class NzbCreator
    {
        private string title = "";
        private string tag = "";
        private string groups = "";

        public string Title
        {
            set { title = value; }
            get { return title; }
        }

        public string Tag
        {
            set { tag = value; }
            get { return tag; }
        }

        public string Groups
        {
            set { groups = value; }
            get { return groups; }
        }

        private XmlDocument xmlDoc;
        private XmlNode rootNode;

        public NzbCreator()
        {
            xmlDoc      = new XmlDocument();
            rootNode    = xmlDoc.CreateElement("nzb");
            xmlDoc.AppendChild(rootNode);
        }

        public void StartFile()
        {
            XmlNode headNode = xmlDoc.CreateElement("head");
            metaTitleTag(headNode);
            metaTagTag(headNode);
            rootNode.AppendChild(headNode);
        }

        public void AppendFile(UsenetFile file)
        {
            XmlNode fileNode = xmlDoc.CreateElement("file");
            
            XmlAttribute posterAttribute = xmlDoc.CreateAttribute("poster");
            posterAttribute.Value = file.Poster;
            fileNode.Attributes.Append(posterAttribute);

            XmlAttribute dateAttribute = xmlDoc.CreateAttribute("date");
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateAttribute.Value = (Math.Round((DateTime.Now - dtDateTime).TotalSeconds)).ToString();
            fileNode.Attributes.Append(dateAttribute);

            XmlAttribute subjectAttribute = xmlDoc.CreateAttribute("subject");
            subjectAttribute.Value = file.Subject;
            fileNode.Attributes.Append(subjectAttribute);

            appendGroups(fileNode, file.Groups);

            appendSegments(fileNode, file);
            rootNode.AppendChild(fileNode);
        }

        private void appendGroups(XmlNode node, List<string> groups)
        {
            XmlNode groupsNode = xmlDoc.CreateElement("groups");

            foreach (string t in groups)
            {
                XmlNode groupNode = xmlDoc.CreateElement("group");
                groupNode.InnerText = t;
                groupsNode.AppendChild(groupNode);
            }

            node.AppendChild(groupsNode);
        }

        private void appendSegments(XmlNode node, UsenetFile file)
        {
            XmlNode segmentsNode = xmlDoc.CreateElement("segments");

            int cnt = 1;
            foreach (UsenetSegment t in file.Segments)
            {
                XmlNode segmentNode = xmlDoc.CreateElement("segment");
                
                XmlAttribute bytesAttribute = xmlDoc.CreateAttribute("bytes");
                bytesAttribute.Value = t.Size.ToString();
                segmentNode.Attributes.Append(bytesAttribute);

                XmlAttribute numberAttribute = xmlDoc.CreateAttribute("number");
                numberAttribute.Value = cnt.ToString();
                segmentNode.Attributes.Append(numberAttribute);
                cnt++;

                segmentNode.InnerText = t.MessageId;
                segmentsNode.AppendChild(segmentNode);
            }

            node.AppendChild(segmentsNode);
        }
        public void SaveFile(string filename)
        {
            xmlDoc.Save(filename);
        }

        private void metaTitleTag(XmlNode node)
        {
            XmlNode metaNode = xmlDoc.CreateElement("meta");
            XmlAttribute attribute = xmlDoc.CreateAttribute("type");
            attribute.Value = "title";
            metaNode.Attributes.Append(attribute);
            metaNode.InnerText = title;
            node.AppendChild(metaNode);
        }

        private void metaTagTag(XmlNode node)
        {
            XmlNode metaNode = xmlDoc.CreateElement("meta");
            XmlAttribute attribute = xmlDoc.CreateAttribute("type");
            attribute.Value = "tag";
            metaNode.Attributes.Append(attribute);
            metaNode.InnerText = tag;
            node.AppendChild(metaNode);
        }
    }
}
