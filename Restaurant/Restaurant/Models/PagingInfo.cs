using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public string Position { get; set; }
        public int TotalPages { get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); } }
    }
}