using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class Singelton
    {
        //для хранения заказов посетителя
        private static Singelton _instens;
        private Conteiner_Check conteiner;
        public static Singelton Instens => _instens ?? (_instens = new Singelton());

        public Singelton()
        {
            conteiner=new Conteiner_Check();
        }
        
        public Conteiner_Check Get_Checks => conteiner;
    }
}