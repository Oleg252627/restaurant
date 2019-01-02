using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class Conteiner_Check
    {
        public List<ModelMenu> Check_orders { get; set; }
        public decimal Summ { get; set; }
        public string ReturnUrl { get; set; }

        public Conteiner_Check()
        {
            Check_orders=new List<ModelMenu>();
            Summ = 0;
        }
        public void Add_ModelMenu(ModelMenu order)
        {
            Summ += order.Prise;
            Check_orders.Add(order);
        }

        public void Remuve_ModelMenu(ModelMenu order)
        {
            Summ -= order.Prise;
            Check_orders.Remove(order);
        }

        public void Clear_ModelMenu()
        {
            Check_orders.Clear();
            Summ = 0;
            ReturnUrl = null;
        }
    }
}