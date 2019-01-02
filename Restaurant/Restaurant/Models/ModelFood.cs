using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Restaurant.Models
{
    public class ModelFood
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Заполните поле Название блюда!")]
        [Display(Name = "Название блюда:")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Заполните поле Описание!")]
        [Display(Name = "Описание:")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Заполните поле Сумма!")]
        [Display(Name = "Цена:")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Введите коректную сумму!")]
        public decimal Prise { get; set; }
        [Required(ErrorMessage = "Выберите позицию!")]
        [Display(Name = "Позиция:")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Выберите картинку!")]
        [Display(Name = "Картинка:")]
        
        public string img { get; set; }
        public HttpPostedFileBase ReternImg { get; set; }

        public ModelFood()
        {
            img = $"~/Images/imeges_icon/default.png";
        }

        public void Set_Img(string url)
        {
            img = "~/" + url;
        }

        public void Get_Img()
        {
            img = img.Trim(new char[] {'~', '/'});
        }
    }
}