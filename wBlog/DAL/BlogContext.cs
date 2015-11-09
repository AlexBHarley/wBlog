using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using wBlog.Models;

namespace wBlog.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("BlogContext")
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }

    
}