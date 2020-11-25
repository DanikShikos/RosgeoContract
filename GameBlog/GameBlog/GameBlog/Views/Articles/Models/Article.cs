using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameBlog.Models
{
    public class Article
    {

        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string FullText { get; set; }
        public DateTime DatePublication { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }

    }

    
}