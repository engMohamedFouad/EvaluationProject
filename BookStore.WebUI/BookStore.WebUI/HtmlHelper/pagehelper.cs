using BookStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace BookStore.WebUI.HtmlHelper
{
    public static class pagehelper
    {
        public static MvcHtmlString pageLinks( this System.Web.Mvc.HtmlHelper html,PagingInfo pageinfo,Func<int,string> pageurl)
        {
            StringBuilder m = new StringBuilder();
            for(int i=1;i<=pageinfo.totalpage;i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href",pageurl(i));
                tag.InnerHtml = i.ToString();
                if(i==pageinfo.currentpage)
                {
                    tag.AddCssClass("Selectd");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                    m.Append(tag.ToString());
            }
            return MvcHtmlString.Create(m.ToString());
        }
    }
}