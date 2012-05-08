using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetNuke.Social.Models.Journal
{
    public class JournalOwner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object Vanity { get; set; }
        public object Avatar { get; set; }
        public int Cacheability { get; set; }
    }
}
