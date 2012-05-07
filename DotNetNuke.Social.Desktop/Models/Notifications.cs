using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DotNetNuke.Social.Models
{
    [DataContract]
    public class Notifications
    {
        public int TotalUnreadMessages { get; set; }
        public int TotalNotifications { get; set; }
    }
}
