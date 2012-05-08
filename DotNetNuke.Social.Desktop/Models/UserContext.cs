using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetNuke.Social.Models
{
    public class UserContext
    {
        public NotificationTop Notifications { get; set; }
        public Credential Credentials { get; set; }
        public System.Exception LastException { get; set; }
        public Inbox Inbox { get; set; }
    }
}
