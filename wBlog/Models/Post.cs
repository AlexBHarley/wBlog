using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wBlog.Models
{
    public class Post
    {
        public Post()
        {
            this.Tags = new List<Tag>();
        }
        public int PostID { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public string Body { get; set; }
        
        public virtual List<Tag> Tags { get; set; }

    }
}