using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.BaseDB;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class CheckController : Controller
    {
        private Singelton singelton = Singelton.Instens;
        // GET: Check
        

        public ActionResult Check_Order()
        {
            return View(singelton.Get_Checks);
        }

        public ActionResult Delete(int? poz)
        {
            if (poz == null)
            {
                return View("Check_Order", singelton.Get_Checks);
            }

            ModelMenu order = singelton.Get_Checks.Check_orders.Find(z => z.Id == poz);
            if (order == null)
            {
                return View("Check_Order", singelton.Get_Checks);
            }
            singelton.Get_Checks.Remuve_ModelMenu(order);
            return View("Check_Order", singelton.Get_Checks);
        }

        public ActionResult Index()
        {
            try
            {
                Create_Check();
                return View();
            }
            catch (Exception e)
            {
                return View("~/Views/_LayoutError.cshtml");
            }
        }

        private void Create_Check()//создание чека и сразу заносятся подробности в другую таблицу
        {
            using (RestaurantEnt db =new RestaurantEnt())
            {
                Checks check = new Checks {Date_of_check = DateTime.Now,Time = DateTime.Now.ToString("HH:mm:ss"),Prase = singelton.Get_Checks.Summ};
                db.Checks.Add(check);
                db.SaveChanges();
                Checks[] checs = db.Checks.ToArray();
                int col = checs.Length - 1;
                foreach (var VARIABLE in singelton.Get_Checks.Check_orders)
                {
                    Check_All all = new Check_All {Id_Checks = checs[col].Id,Name_food = VARIABLE.Name,Prise = VARIABLE.Prise};
                    db.Check_All.Add(all);
                }

                db.SaveChanges();
            }
            singelton.Get_Checks.Clear_ModelMenu();
        }
    }
}