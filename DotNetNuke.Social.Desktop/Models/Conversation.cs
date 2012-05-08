using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetNuke.Social.Models
{
    public class Conversation
    {
        public int RowNumber { get; set; }
        public int AttachmentCount { get; set; }
        public int NewThreadCount { get; set; }
        public int ThreadCount { get; set; }
        public string SenderProfileUrl { get; set; }
        public int MessageID { get; set; }
        public int PortalID { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int ConversationId { get; set; }
        public bool ReplyAllAllowed { get; set; }
        public int SenderUserID { get; set; }
        public string DisplayDate { get; set; }
        public int KeyID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public int LastModifiedByUserID { get; set; }
        public DateTime LastModifiedOnDate { get; set; }
    }
}