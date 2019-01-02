using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.BaseDB;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class PositionController : Controller
    {
        // GET: Position
        public ActionResult Index()
        {
            try
            {
                return View(Get_Positions());
            }
            catch (Exception e)
            {
                return View("~/Views/_LayoutError.cshtml");
            }
        }

        public List<ModelPosition> Get_Positions()
        {
            List<ModelPosition> lists=new List<ModelPosition>();
            using (RestaurantEnt db = new RestaurantEnt())
            {
                var pos = db.Position.ToList();
                foreach (var VARIABLE in pos)
                {
                    ModelPosition model = new ModelPosition {Id = VARIABLE.Id, Position = VARIABLE.Name_Posinion};
                    lists.Add(model);
                }
            }

            return lists;
        }

        public PartialViewResult AddPosition()//добавление позиции частичное представление
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult AddPosition(ModelPosition pos)
        {
            if (ModelState.IsValid)
            {
                using (RestaurantEnt db = new RestaurantEnt())
                {
                    Position position = new Position {Name_Posinion = pos.Position};
                    db.Position.Add(position);
                    db.SaveChanges();
                }
                return PartialView("TablePosition",Get_Positions());
            }
            else
            {
                return PartialView();
            }
            
        }
        [HttpGet]
        public PartialViewResult Edit(int id)//редактирование
        {

            return PartialView(Get_Id_Position(id));
        }
        [HttpPost]
        public PartialViewResult Edit(ModelPosition model, int id)
        {
            if (ModelState.IsValid)
            {
                Save_Position(model,id);
                return PartialView("TablePosition", Get_Positions());
            }
            else
            {
                return PartialView(model);
            }
            
        }

        public PartialViewResult Delete(int id)//удаление
        {
            using (RestaurantEnt db = new RestaurantEnt())
            {
                var food = db.Menu.Where(z => z.id_Position == id).ToList();
                if (food.Count!=0)
                {
                    foreach (var VARIABLE in food)//удаляю все блюда которые закреплены к категории
                    {
                        db.Menu.Remove(VARIABLE);
                    }
                }

                var pos = db.Position.FirstOrDefault(z => z.Id == id);
                if (pos!=null)
                {
                    db.Position.Remove(pos);
                    db.SaveChanges();
                }
            }

            return PartialView("TablePosition", Get_Positions());
        }
        private void Save_Position(ModelPosition model, int id)//сохранение в базу
        {
            using (RestaurantEnt db = new RestaurantEnt())
            {
                var pos = db.Position.FirstOrDefault(z => z.Id == id);
                if (pos != null) { pos.Name_Posinion = model.Position; }
               
                db.SaveChanges();
            }
        }

        private object Get_Id_Position(int id)
        {
            ModelPosition model=new ModelPosition();
            using (RestaurantEnt db = new RestaurantEnt())
            {
                var pos = db.Position.FirstOrDefault(z => z.Id == id);
                model.Id = pos.Id;
                model.Position = pos.Name_Posinion;
            }

            return model;
        }
    }
}