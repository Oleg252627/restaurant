using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.BaseDB;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        private Singelton singelton = Singelton.Instens;
        public int PageSize = 4;
        // GET: Home
        public ActionResult ListMenu(string position=null, int pages=1)// все продукты
        {
            try
            {
                return View(Get_Menu(position,pages));
            }
            catch (Exception e)
            {
                return View("~/Views/_LayoutError.cshtml");
            }
        }
        public PartialViewResult Index(int id = 0, string returnUrl = null)//частичное представление заказа
        {
            try
            {
                ModelMenu mod = GetOrder(id);
                if (mod != null)
                {
                    singelton.Get_Checks.ReturnUrl = returnUrl;
                    singelton.Get_Checks.Add_ModelMenu(mod);
                }
                return PartialView(singelton.Get_Checks);
            }
            catch (Exception e)
            {
                return PartialView("~/Views/_LayoutError.cshtml");
            }
        }
        public ModelMenu GetOrder(int id)// метод для получения блюда из базы и сохраняем в контеинер
        {
            ModelMenu order = null;
            using (RestaurantEnt db = new RestaurantEnt())
            {
                var or = db.Menu.FirstOrDefault(z => z.Id == id);
                if (or != null)
                {
                    order = new ModelMenu
                    {
                        Description = or.Descriptions,
                        Id = or.Id,
                        Img = or.Img,
                        Name = or.Name_food,
                        Prise = or.Prise
                    };
                }
            }

            return order;
        }

        public Model_List_Peges Get_Menu(string position, int pages)//достаю из базы по 4 позиции 
        {
            
            Model_List_Peges listPeges = new Model_List_Peges();

            using (RestaurantEnt db =new RestaurantEnt())
            {
                var menu = position == null
                    ? db.Menu.OrderBy(z => z.Id).Skip((pages - 1) * PageSize).Take(PageSize).ToList()
                    : db.Menu.Where(z => z.Position.Name_Posinion == position).OrderBy(z => z.Id)
                        .Skip((pages - 1) * PageSize).Take(PageSize).ToList();

                listPeges.pagingInfo.CurrentPage = pages;
                listPeges.pagingInfo.ItemsPerPage = PageSize;
                listPeges.pagingInfo.Position = position;
                listPeges.pagingInfo.TotalItems = position == null
                    ? db.Menu.ToList().Count
                    : db.Menu.Where(z => z.Position.Name_Posinion == position).ToList().Count;
                foreach (var VARIABLE in menu)
                {
                    ModelMenu model = new ModelMenu { Id = VARIABLE.Id, Name = VARIABLE.Name_food, Description = VARIABLE.Descriptions, Prise = VARIABLE.Prise, Img = VARIABLE.Img };
                    listPeges.menu.Add(model);
                }

            }
            return listPeges;
        }

    }
}