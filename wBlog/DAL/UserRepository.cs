using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wBlog.Models;

namespace wBlog.DAL
{
    public class UserRepository
    {
        UserContext context = new UserContext();

        public User GetUserByUsernameAndPassword(User user)
        {
            return context.Users
                .Where(u => u.Username == user.Username & u.Password == user.Password).First();
        }

        public void CreateUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}