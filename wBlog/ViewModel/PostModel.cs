using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wBlog.Models;

namespace wBlog.ViewModel
{
    public class PostModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime DatePosted { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
    

}