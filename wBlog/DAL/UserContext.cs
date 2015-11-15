using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using wBlog.Models;

namespace wBlog.DAL
{
    public class UserContext : DbContext
    {
        public UserContext() : base("BlogContext")
        {}

        public DbSet<User> Users { get; set; }
    }
}