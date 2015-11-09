using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wBlog.Models
{
    public class Tag
    {
        public int PostID { get; set; }
        public int TagID { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }

        
    }
}