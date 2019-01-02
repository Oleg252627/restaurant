using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Model_Check
    {
        public int Id { get; set; }
        [Display(Name = "Дата чека")]
        public DateTime Data_of_check { get; set; }
        [Display(Name = "Время чека")]
        public string Time { get; set; }
        [Display(Name = "Сумма заказа")]
        public decimal Prise { get; set; }
    }
}