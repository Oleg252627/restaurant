using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.BaseDB;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            try
            {
                Show_Position();
                return View(GetMenu());
            }
            catch (Exception e)
            {
                return View("~/Views/_LayoutError.cshtml");
            }
        }

        public List<Model_Table_Menu> GetMenu()
        {
            List<Model_Table_Menu> list = new List<Model_Table_Menu>();
            using (RestaurantEnt db=new RestaurantEnt())
            {
                var menu = db.Menu.ToList();
                foreach (var VARIABLE in menu)
                {
                    Model_Table_Menu food = new Model_Table_Menu
                        {Id = VARIABLE.Id, Title = VARIABLE.Name_food, Prise = VARIABLE.Prise};
                    list.Add(food);
                }
            }

            return list;
        }
        [HttpPost]
        public PartialViewResult Sorted(string PositionId)//сортировка по позициям
        {
            int poz= Int32.Parse(PositionId);
            List<Model_Table_Menu> list = new List<Model_Table_Menu>();
            using (RestaurantEnt db=new RestaurantEnt())
            {
                var menu = db.Menu.Where(z=>z.id_Position==poz).ToList();
                foreach (var VARIABLE in menu)
                {
                    Model_Table_Menu food = new Model_Table_Menu
                        { Id = VARIABLE.Id, Title = VARIABLE.Name_food, Prise = VARIABLE.Prise };
                    list.Add(food);
                }
            }

            return PartialView(list);
        }
        public void Show_Position()//для отображения в DropDownlist
        {
            List<SelectListItem> item = new List<SelectListItem>();
            using (RestaurantEnt db = new RestaurantEnt())
            {
                foreach (var VARIABLE in db.Position)
                {
                    item.Add(new SelectListItem{Text = VARIABLE.Name_Posinion,Value = $"{VARIABLE.Id}"});
                }
            }

            ViewBag.items = item;
        }
        [HttpGet]
        public ActionResult AddFood()// добавление блюда
        {
            Show_Position();
            ModelFood food=new ModelFood();
            return View(food);
        }
        [HttpPost]
        public ActionResult AddFood(ModelFood food)
        {
            if (ModelState.IsValid)
            {
                SaveFood(food);
                return RedirectToAction("Index");
            }
            else
            {
                Show_Position();
                return View(food);
            }
            
        }
        [HttpGet]
        public ActionResult EditFood(int id)//редактирование
        {
            ModelFood food;
            using (RestaurantEnt db=new RestaurantEnt())
            {
                var menu = db.Menu.FirstOrDefault(z => z.Id == id);
                food = new ModelFood
                {
                    Id = menu.Id, Name = menu.Name_food, Description = menu.Descriptions, Prise = menu.Prise,
                    Position = menu.id_Position.ToString()
                };
                food.Set_Img(menu.Img);
                Edit_Show_Position(menu.id_Position);
            }
            
            return View(food);
        }
        [HttpPost]
        public ActionResult EditFood(ModelFood food, int Id,string img)
        {
            if (ModelState.IsValid)
            {
                Edit_SaveFood(food,Id,img);
                return RedirectToAction("Index");
            }
            else
            {
                Edit_Show_Position(Int32.Parse(food.Position));
                return View(food);
            }
        }

        private void Edit_SaveFood(ModelFood food, int Id, string img)
        {
            Save_Img(food, img);
            using (RestaurantEnt db = new RestaurantEnt())
            {
                var menu = db.Menu.FirstOrDefault(z => z.Id == Id);
                menu.Name_food = food.Name;
                menu.Descriptions = food.Description;
                menu.id_Position = Int32.Parse(food.Position);
                menu.Prise = food.Prise;
                menu.Img = food.img;
                db.SaveChanges();
            }
        }

        private void Edit_Show_Position(int id)//метод для редактирования для показа существующей позиции
        {
            List<SelectListItem> item = new List<SelectListItem>();
            using (RestaurantEnt db = new RestaurantEnt())
            {
                foreach (var VARIABLE in db.Position)
                {
                    if (id==VARIABLE.Id)
                    {
                        item.Add(new SelectListItem { Text = VARIABLE.Name_Posinion, Value = $"{VARIABLE.Id}",Selected = true});
                    }
                    else
                    {
                        item.Add(new SelectListItem { Text = VARIABLE.Name_Posinion, Value = $"{VARIABLE.Id}" });
                    }
                }
            }

            ViewBag.items = item;
        }

        private void Save_Img(ModelFood food, string img)//добавление картинки после редактирования
        {
            if (food.ReternImg != null)
            {
                string filaName = Path.GetFileNameWithoutExtension(food.ReternImg.FileName);
                string exstension = Path.GetExtension(food.ReternImg.FileName);
                filaName = filaName + DateTime.Now.ToString("yy-MM-dd") + exstension;
                food.img = $"Images/images_food/" + filaName;
                food.ReternImg.SaveAs(Path.Combine(Server.MapPath("~/Images/images_food/"), filaName));
            }
            else
            {
                food.img = img;
                food.Get_Img();
            }
        }
        private void SaveFood(ModelFood food)
        {
            Save_Img_Add(food);
            using (RestaurantEnt db = new RestaurantEnt())
            {
                Menu menu = new Menu
                {
                    Img = food.img, Name_food = food.Name, Descriptions = food.Description, Prise = food.Prise,
                    id_Position = Int32.Parse(food.Position)
                };
                db.Menu.Add(menu);
                db.SaveChanges();
            }
        }

        private void Save_Img_Add(ModelFood food)//добавление картинки
        {
            if (food.ReternImg != null)
            {
                string filaName = Path.GetFileNameWithoutExtension(food.ReternImg.FileName);
                string exstension = Path.GetExtension(food.ReternImg.FileName);
                filaName = filaName + DateTime.Now.ToString("yy-MM-dd") + exstension;
                food.img = $"Images/images_food/" + filaName;
                food.ReternImg.SaveAs(Path.Combine(Server.MapPath("~/Images/images_food/"), filaName));
            }
            else
            {
                food.Get_Img();
            }
        }

        public PartialViewResult Delete(int id)//удаление Ajax линком
        {
            
            List<Model_Table_Menu> list = new List<Model_Table_Menu>();
            using (RestaurantEnt db = new RestaurantEnt())
            {
                var food = db.Menu.FirstOrDefault(z => z.Id == id);
                db.Menu.Remove(food);
                db.SaveChanges();
                foreach (var VARIABLE in db.Menu)
                {
                    Model_Table_Menu model = new Model_Table_Menu
                        { Id = VARIABLE.Id, Title = VARIABLE.Name_food, Prise = VARIABLE.Prise };
                    list.Add(model);
                }
            }

            return PartialView("Sorted",list);
        }
    }
}