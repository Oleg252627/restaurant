using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.BaseDB;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Model_Admin admin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Get_Valid(admin))
                    {
                        return RedirectToAction("Index","Cabinet");
                    }
                    else
                    {
                        ModelState.AddModelError("","Вы ввели не верный Login или Password!");
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                return View("~/Views/_LayoutError.cshtml");
            }
        }

        

        public bool Get_Valid(Model_Admin admin)// проверка на правильность написания логин и пароль
        {
            using (RestaurantEnt db =new RestaurantEnt())
            {
                var user = db.Admin.Where(z => z.Name == admin.Login && z.Passvord == admin.Password).ToList();
                if (user.Count != 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}