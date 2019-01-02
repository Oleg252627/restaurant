using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class ModelMore
    {
        [Display(Name = "Время чека")]
        public string Time { get; set; }
        [Display(Name = "Название блюда")]
        public string Name { get; set; }
        [Display(Name = "Цена блюда")]
        public decimal Prise { get; set; }
    }
}