using Restaurant.BaseDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class CabinetController : Controller
    {
        // GET: Cabinet
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tabel_Check()
        {
            try
            {
                return View(GetChecks());
            }
            catch (Exception e)
            {
                return View("~/Views/_LayoutError.cshtml");
            }
        }
        public PartialViewResult More(int id)//подробности чека
        {
            return PartialView(GetAlls_More(id));
        }

        public PartialViewResult Day()//сортировка заказы за день
        {
            List<Model_Check> Listchecs=new List<Model_Check>();
            using (RestaurantEnt db =new RestaurantEnt())
            {
                var checks = db.Checks.Where(z => z.Date_of_check.Day == DateTime.Now.Day).ToList();
                foreach (var VARIABLE in checks)
                {
                    Model_Check check = new Model_Check
                    {
                        Data_of_check = VARIABLE.Date_of_check, Id = VARIABLE.Id, Time = VARIABLE.Time,
                        Prise = VARIABLE.Prase
                    };
                    Listchecs.Add(check);
                }
            }

            return PartialView(Listchecs);
        }
        public PartialViewResult Month()//за месяц
        {
            List<Model_Check> Listchecs = new List<Model_Check>();
            using (RestaurantEnt db = new RestaurantEnt())
            {
                var checks = db.Checks.Where(z => z.Date_of_check.Month == DateTime.Now.Month).ToList();
                foreach (var VARIABLE in checks)
                {
                    Model_Check check = new Model_Check
                    {
                        Data_of_check = VARIABLE.Date_of_check,
                        Id = VARIABLE.Id,
                        Time = VARIABLE.Time,
                        Prise = VARIABLE.Prase
                    };
                    Listchecs.Add(check);
                }
            }

            return PartialView("Day",Listchecs);
        }
        public PartialViewResult Year()//за год
        {
            List<Model_Check> Listchecs = new List<Model_Check>();
            using (RestaurantEnt db = new RestaurantEnt())
            {
                var checks = db.Checks.Where(z => z.Date_of_check.Year == DateTime.Now.Year).ToList();
                foreach (var VARIABLE in checks)
                {
                    Model_Check check = new Model_Check
                    {
                        Data_of_check = VARIABLE.Date_of_check,
                        Id = VARIABLE.Id,
                        Time = VARIABLE.Time,
                        Prise = VARIABLE.Prase
                    };
                    Listchecs.Add(check);
                }
            }

            return PartialView("Day", Listchecs);
        }

        public List<ModelMore> GetAlls_More(int id)
        {
            List<ModelMore> lists=new List<ModelMore>();
            using (RestaurantEnt db = new RestaurantEnt())
            {
                var list = db.Check_All.Where(z => z.Id_Checks == id).ToList();
                foreach (var VARIABLE in list)
                {
                    ModelMore more = new ModelMore
                    {
                        Time = VARIABLE.Checks.Time, Name = VARIABLE.Name_food,
                        Prise = VARIABLE.Prise
                    };
                    lists.Add(more);
                }
            }

            return lists;
        }
        public List<Checks> GetChecks()
        {
            List<Checks> checkses = null;
            using (RestaurantEnt db =new RestaurantEnt())
            {
                checkses = db.Checks.ToList();
            }

            return checkses;
        }
    }
}