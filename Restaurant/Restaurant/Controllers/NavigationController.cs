using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.BaseDB;

namespace Restaurant.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Navigation
        public PartialViewResult Index(string position=null)
        {
            try
            {
                ViewBag.pos = position;
                List<string> positiEnumerable = GetPosition();
                return PartialView(positiEnumerable);
            }
            catch (Exception e)
            {
                return PartialView("~/Views/_LayoutError.cshtml");
            }
        }

        private List<string> GetPosition()
        {
            List<string> var;
            using (RestaurantEnt db =new RestaurantEnt())
            {
                var = db.Position.Select(z => z.Name_Posinion).ToList();
                
            }

            return var;
        }
    }
}