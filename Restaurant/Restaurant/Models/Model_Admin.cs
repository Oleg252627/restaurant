using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Model_Admin
    {
        [Required(ErrorMessage = "Заполните поле Login!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Заполните поле Password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}