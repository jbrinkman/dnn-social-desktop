using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetNuke.Social.Models
{

    public class Notification
    {
        public int NotificationId { get; set; }
        public string Subject { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public string DisplayDate { get; set; }
        public string SenderAvatar { get; set; }
        public string SenderProfileUrl { get; set; }
        public List<Action> Actions { get; set; }
    }
}
