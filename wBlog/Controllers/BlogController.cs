using wBlog.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var allPosts = db.Posts.Where(t => t.Id != 0)
                .OrderByDescending(t => t.DateTime).ToList();
            
            List<PostModel> postList = new List<PostModel>();
           
            foreach(var x in allPosts)
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

        public ActionResult Search(int id)
        {
            var posts = db.Posts.Where(p => p.Tags.Any(t => t.Id == id));
            List<PostModel> postModelList = new List<PostModel>();
            foreach (var post in posts)
            {
                postModelList.Add(new PostModel
                {
                    Title = post.Title,
                    Body = post.Body,
                    DatePosted = post.DateTime,
                    Tags = post.Tags
                });
            }
           
            return View("Index", postModelList);

        }

        [HttpPost]
        public ActionResult Search(string searchString)
        {
            var posts = db.Posts
                .Where(p => p.Body.Contains(searchString) /*|| p.Title.Contains(searchString) */);
            List<PostModel> postList = new List<PostModel>();
            foreach (var post in posts)
            {
                Debug.WriteLine(post.Title);
                postList.Add(new PostModel
                {
                    Title = post.Title,
                    Body = post.Body,
                    DatePosted = post.DateTime,
                    Tags = post.Tags
                });
            }
            return View("Index", postList);
        }

        public ActionResult SideBar()
        {
            var tags = db.Tags.Where(x => x.Id != 0).Distinct().Take(8).ToList();

            List<Tag> tagList = new List<Tag>();
            foreach (var tag in tags)
            {
                tagList.Add(new Tag
                {
                    Id = tag.Id,
                    Name = tag.Name
                });
            }
            return PartialView("Sidebar", new SidebarViewModel(tagList));

        }


    }
}