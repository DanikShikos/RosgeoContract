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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(CreateArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                Article article = new Article
                {
                    CategoryId = model.CategoryId,
                    DatePublication = DateTime.Now,
                    Title = model.Title,
                    FullText = model.Fulltext,
                    ApplicationUserId = User.Identity.GetUserId()                                   
                };
                db.Articles.Add(article);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            SelectList category = new SelectList(db.Categories, "Id", "Title");
            ViewBag.Category = category;
            return View(model);
        }

        public async Task<ActionResult> Edit(int id)
        {
            Article article = await db.Articles.FindAsync(id);

            if (article == null)
            {
                return RedirectToAction("Index");
            }

            UpdateArticleViewModel model = new UpdateArticleViewModel
            {
                Id = article.ArticleId,
                CategoryId = article.CategoryId,
                Fulltext = article.FullText,
                Title = article.Title
            };
            SelectList category = new SelectList(db.Categories, "Id", "Title");
            ViewBag.Category = category;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateArticleViewModel model)
        {
            Article article = await db.Articles.FindAsync(model.Id);
            if (ModelState.IsValid)
            {
                article.CategoryId = model.CategoryId;
                article.FullText = model.Fulltext;
                article.Title = model.Title;

                db.Entry(article).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            SelectList category = new SelectList(db.Categories, "Id", "Title");
            ViewBag.Category = category;

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            Article article = await db.Articles.FindAsync(id);
            if (article == null)
            {
                return RedirectToAction("Index");
            }
            return View(article);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Article article = await db.Articles.FindAsync(id);
            if (article == null)
            {
                return RedirectToAction("Index");
            }
            db.Articles.Remove(article);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}