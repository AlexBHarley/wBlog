using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using wBlog.DAL;
using wBlog.Models;
using wBlog.ViewModel;

namespace wBlog.Controllers
{
    public class UserController : Controller
    {
        UserRepository userRepo = new UserRepository();
        SessionContext context = new SessionContext();

        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var authenticatedUser = userRepo.GetUserByUsernameAndPassword(user);
            if (authenticatedUser != null)
            {
                context
                    .SetAuthenticationToken(authenticatedUser.UserId.ToString(), false, authenticatedUser);

                return RedirectToAction("Index", "Blog");
            }

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                userRepo.CreateUser(new User
                {
                    Name = model.Name,
                    Password = model.Password
                });
                RedirectToAction("Login", "User");
            }
            return RedirectToAction("Index", "Blog");
        }
    }
}