using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetNuke.Social.Models.Journal
{
    public class ItemData
    {
        public object Url { get; set; }
        public object Title { get; set; }
        public object Description { get; set; }
        public object ImageUrl { get; set; }
        public int Cacheability { get; set; }
    }
}
