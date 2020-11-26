using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RosGeoDevOps.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Начальная страница RGDevOps.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Контакты RGDevOps.";

            return View();
        }
    }
}