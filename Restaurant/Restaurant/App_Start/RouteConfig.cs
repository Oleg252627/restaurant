using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Restaurant
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(null, "", new { controller = "Home", action = "ListMenu", position = (string)null, pages = 1 });
            
            routes.MapRoute(null, "Page{pages}", new { controller = "Home", action = "ListMenu", position = (string) null }, new { pages = @"\d+" });
            routes.MapRoute(null, "{position}", new { controller = "Home", action = "ListMenu", pages = 1 });
            routes.MapRoute(null, "{position}/Page{pages}", new {controller = "Home", action = "ListMenu"},
                new {pages = @"\d+"});
            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
