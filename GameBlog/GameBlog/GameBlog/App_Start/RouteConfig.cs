using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GameBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null,
                "",
                new { controller = "Home",action = "Index",page = 1},
                namespaces: new[] { "GameBlog.Controllers" }
                );

            routes.MapRoute("IndexPages",               
                "Page{page}",
                new { controller = "Home",action = "Index"},
                new { page = @"\d+"},
                namespaces: new[] { "GameBlog.Controllers" }
                );

            routes.MapRoute(
                "News",
                url:"news/{news}",
                defaults: new { controller="Home",action="News"},
                constraints: new { news = @"\d+" },
                namespaces: new[] { "GameBlog.Controllers" }
                );

            routes.MapRoute(
                "CategoriesStartPage",
                "{name}",
                new { controller = "Home",action = "Category", page = 1},
                namespaces: new[] { "GameBlog.Controllers" }
                );

            routes.MapRoute(
                "CategoryAndPages",
                "{name}/{page}",
                new { controller = "Home",action = "Category"},
                new { page = @"\d+"},
                namespaces: new[] { "GameBlog.Controllers" }
                );
         
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "GameBlog.Controllers"}
            );

            
        }
    }
}
    