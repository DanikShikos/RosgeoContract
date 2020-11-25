using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace GameBlog.Areas.Admin.Models
{
    public class ArticlesListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class CreateArticleViewModel
    {
        [Required(ErrorMessage = "Вы не ввели название статьи!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Вы не ввели текст статьи!")]
        public string Fulltext { get; set; }

        [Required(ErrorMessage = "Вы не выбрали категорию")]
        public int? CategoryId { get; set; }
    }

    public class UpdateArticleViewModel:CreateArticleViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        
    }
}