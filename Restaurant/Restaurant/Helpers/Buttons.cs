using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;

namespace Restaurant.Helpers
{
    public static class Buttons
    {
        //Для отображения страниц блюд
        public static MvcHtmlString PagesLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pagUrl)
        {
            StringBuilder result=new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag=new TagBuilder("a");
                tag.MergeAttribute("href",pagUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                }

                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}