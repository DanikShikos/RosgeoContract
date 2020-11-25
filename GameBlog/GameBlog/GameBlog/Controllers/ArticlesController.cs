using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using GameBlog.Areas.Admin.Models;
using GameBlog.Models;
using System.Data.Entity;

namespace GameBlog.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ArticlesController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        // GET: Admin/Articles
        public async Task<ActionResult> Index()
        {
           
           IEnumerable<Article> articles = await db.Articles.ToListAsync();
           IEnumerable<ArticlesListViewModel> list = articles.OrderByDescending(x => x.ArticleId).Select(x => new ArticlesListViewModel { Id = x.ArticleId, Title = x.Title });
           return View(list);      
        }

        [HttpGet]
        public ActionResult Add()
        {        
           SelectList category = new SelectList(db.Categories, "Id", "Title");            
           ViewBag.Category = category;
           return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                Article article = new Article
                {
                    CategoryId = model.CategoryId,
                    DatePublication = DateTime.Now,
                    Title = model.Title,
                    FullText = model.Fulltext
                };
                db.Articles.Add(article);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}