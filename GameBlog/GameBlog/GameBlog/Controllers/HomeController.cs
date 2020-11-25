using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameBlog.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace GameBlog.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        
        
        public async Task<ActionResult> Index(int page = 1)
        {
            
            int pageSize = 3;
            IEnumerable<Article> articles = await db.Articles
                .Include(a=>a.Category)
                .OrderByDescending(a=>a.ArticleId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = db.Articles.Count() };
            IndexViewModel<Article> ivm = new IndexViewModel<Article>() { Articles = articles,pageInfo = pageInfo};

            return View(ivm);
        }

        public ActionResult News(int? news)
        {
            if (news == null)
            {
                return RedirectToAction("Index");
            }
            Article article = db.Articles
                .Include(a=>a.Category)
                .Include(a=>a.ApplicationUser)
                .FirstOrDefault(n=>n.ArticleId == news.Value);

            return View(article);
        }

        public ActionResult Category(string name,int page = 1)
        {
            Category category = db.Categories.Include(p => p.Articles).FirstOrDefault(t => t.Title == name.ToString());
            if (category == null)
            {
                return RedirectToAction("Index");
            }

            int pageSize = 3;
            IEnumerable<Article> articles = category.Articles.OrderBy(a => a.ArticleId).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = category.Articles.Count() };
            IndexViewModel<Article> ivm = new IndexViewModel<Article>() { Articles = articles, pageInfo = pageInfo };

            ViewBag.Title = name;
            return View(ivm);
        }
    }
}