using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wBlog.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public string Body { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get
            {
                if (_tags == null)
                {
                    _tags = new Collection<Tag>();
                }
                return _tags;
            }
            set { _tags = value; }
        }

        private ICollection<Tag> _tags;
    }
}