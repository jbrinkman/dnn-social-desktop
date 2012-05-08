using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetNuke.Social.Models.Journal
{
    public class Journal
    {
        public int JournalId { get; set; }
        public int JournalTypeId { get; set; }
        public int PortalId { get; set; }
        public int UserId { get; set; }
        public int ProfileId { get; set; }
        public int SocialGroupId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public object Body { get; set; }
        public ItemData ItemData { get; set; }
        public object JournalXML { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string ObjectKey { get; set; }
        public string AccessKey { get; set; }
        public object SecuritySet { get; set; }
        public int ContentItemId { get; set; }
        public JournalAuthor JournalAuthor { get; set; }
        public JournalOwner JournalOwner { get; set; }
        public object TimeFrame { get; set; }
        public bool CurrentUserLikes { get; set; }
        public string JournalType { get; set; }
        public int KeyID { get; set; }
        public int Cacheability { get; set; }
    }
}
