using wBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using wBlog.ViewModel;

namespace wBlog.Controllers
{
    public class BlogController : Controller
    {
        private BlogContext db = new BlogContext();
        
        public ActionResult Index()
        {
            
            var justCreate = from s in db.Posts
                             select s;
            List<PostModel> postList = new List<PostModel>();
           
            foreach(var x in justCreate)
            {
                postList.Add(new PostModel
                {
                    Title = x.Title,
                    Body = x.Body,
                    Tags = x.Tags

                });
            }

            return View(postList);
        }
        
        

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Title,Body,Tags")] BlogInputModel input)
        {
            if (ModelState.IsValid)
            {
                Post post = new Post
                {
                    Title = input.Title,
                    Body = input.Body,
                    DateTime = DateTime.Now
                };
                post.Tags.Clear();

                foreach (string word in input.Tags.Split(' '))
                {
                    Tag tag = new Tag
                    {
                        Name = word
                    };
                    post.Tags.Add(tag);
                }

                db.Posts.Add(post);
                db.SaveChanges();
                
                
                return RedirectToAction("Details", new { id = post.Id });
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var post = db.Posts.Where(x => x.Id == id).First();
            PostModel model = new PostModel
            {
                Body = post.Body,
                DatePosted = post.DateTime,
                Title = post.Title,
                Tags = post.Tags
            };
            
            return View(model);
        }
    }
}