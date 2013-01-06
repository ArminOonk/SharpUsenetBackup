using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpUsenetBackup
{
    class UsenetSegment
    {
        
        private string messageId = "";
        private int size = 0;
        
        public string MessageId
        {
            get { return messageId; }
            set { messageId = value; }
        }

        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public UsenetSegment( string _messageId, int _size)
        {
            messageId = _messageId;
            size = _size;
        }
    }

    class UsenetFile
    {
        private List<UsenetSegment> segments;
        private string subject = "";
        private List<string> groups;
        private string poster;

        public List<string> Groups
        {
            get { return groups; }
            set { groups = value; }
        }

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public string Poster
        {
            get { return poster; }
            set { poster = value; }
        }

        public List<UsenetSegment> Segments
        {
            get { return segments; }
            set { segments = value; }
        }

        public UsenetFile(string _subject, string _groups, string _poster)
        {
            subject = _subject;
            poster = _poster;
            string[] tmpGroups = _groups.Split(',');
            groups = new List<string>(tmpGroups);

            segments = new List<UsenetSegment>();
        }

        public void Append(string messageId, int size)
        {
            segments.Add(new UsenetSegment(messageId, size));
        }

        public void Clear()
        {
            segments.Clear();
        }
    }
}
