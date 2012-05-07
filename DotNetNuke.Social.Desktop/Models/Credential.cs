using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetNuke.Social.Models
{
    public class Credential
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Site { get; set; }

        public bool IsValid
        {
            get
            {
                return !(string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Site));
            }
        }
    }
}
