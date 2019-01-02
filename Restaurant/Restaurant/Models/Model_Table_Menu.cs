using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Model_Table_Menu
    {
        public int Id { get; set; }
        [Display(Name = "Название блюда")]
        public string Title { get; set; }
        [Display(Name = "Цена блюда")]
        public decimal Prise { get; set; }
    }
}