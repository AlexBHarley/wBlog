using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wBlog.Models;

namespace wBlog.ViewModel
{
    public class SidebarViewModel
    {
        public string x { get; set; }
        public List<Tag> Col1Tags { get; set; }
        public List<Tag> Col2Tags { get; set; }

        public SidebarViewModel(List<Tag> tagList)
        {
            Col1Tags = new List<Tag>(); //Splits 8 tags into two columns for view
            Col2Tags = new List<Tag>();

            int c = 0;
            foreach (var tag in tagList)
            {
                if (c < 4) { Col1Tags.Add(tag); }
                else { Col2Tags.Add(tag); }
                c++;
            }
        }
    }
}