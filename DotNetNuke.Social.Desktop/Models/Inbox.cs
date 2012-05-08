using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetNuke.Social.Models
{
    public class Inbox
    {
        public int TotalConversations { get; set; }
        public int TotalNewThreads { get; set; }
        public List<Conversation> Conversations { get; set; }
    }
}
