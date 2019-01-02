using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class Model_List_Peges
    {
        public List<ModelMenu> menu { get; set; }
        public PagingInfo pagingInfo { get; set; }

        public Model_List_Peges()
        {
            pagingInfo=new PagingInfo();
            menu =new List<ModelMenu>();
        }
    }
}