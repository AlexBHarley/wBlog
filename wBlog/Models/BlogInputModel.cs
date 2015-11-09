using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wBlog.Models
{
    public class BlogInputModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Tags { get; set; }
    }
}