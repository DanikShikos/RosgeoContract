using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameBlog.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Article> Articles { get; set; }

        public Category()
        {
            Articles = new List<Article>();
        }
    }
}