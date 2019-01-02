using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class ModelPosition
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Заполните поле Категория!")]
        [Display(Name = "Категория")]
        [DataType(DataType.Text)]
        public string Position { get; set; }
    }
}