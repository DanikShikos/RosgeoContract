using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using GameBlog.Models;
using GameBlog.Areas.Admin.Models;
namespace GameBlog.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private ApplicationContext db;

        // GET: Admin/Home
        public  ActionResult Index()
        {
            db = new ApplicationContext();
            var articles = db.Articles.Count();
            var users = db.Users.Count();
            return View(new AdminIndexViewModel {QuantityArticles = articles,QuantityUsers = users});
        }


    }
}