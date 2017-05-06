using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWork.WebMVC.Extension
{
    public static class CheckBoxExtension
    {

        //This extension method is created for replacement of defualt checkbox of html helper method

        public static MvcHtmlString PlusCheckBox(this HtmlHelper htmlHelper, string name, bool isChecked,int productId)
        {
            var builder = new TagBuilder("PlusCheck");

            if (isChecked)
            {
                return MvcHtmlString.Create("<button  type=\"button\" class=\"GyfoBtn GyfoBtn-default GyfoBtn-disabled\" data-id=\""+productId+"\" aria-label=\"Left Align\"> <span class=\"glyphicon glyphicon-plus\" id=\"checkChange\" aria-hidden=\"true\"></span> </button>");
                 
            }
            else
            {
                return MvcHtmlString.Create("<button  type=\"button\" class=\"GyfoBtn GyfoBtn-default\"  data-id=\"" + productId +"\" aria-label=\"Left Align\"> <span class=\"glyphicon glyphicon-plus\" id=\"checkChange\" aria-hidden=\"true\"></span> </button>");    
            }
        }

        public static MvcHtmlString MinusCheckBox(this HtmlHelper htmlHelper, string name, int productId)
        {
            var builder = new TagBuilder("MinusCheck");

            return MvcHtmlString.Create("<button  type=\"button\" class=\"GyfoBtn GyfoBtn-default\" data-id=\"" + productId + "\"  aria-label=\"Left Align\"> <span class=\"glyphicon glyphicon-minus\" id=\"checkChange\" aria-hidden=\"true\"></span> </button>");
            
        }
    }
}