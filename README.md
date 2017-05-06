# AdventureWorkMVC-With-n-tier
his sample shows you how you can design your n-tier MVC web application. This project also conclude test project and code analysis
and code metrics which have been put in report folder.this sample is using Entity framework 6 with database first approach.
Futher the project description and every deatils is provided inside the project file.
This sample is also using how to use custom htmlhelper method to design your own custom control.


This is sample MVC 4 website with n-tier (onion architecture).This sample has been designed as real time project perspective.This project is using Entity framework for DB coneectivity and following repository pattern. Building the Sample

Please download adventureWorks2008 databse and attach mdf file in sql server. The database link is given here:

http://msftdbprodsamples.codeplex.com/releases/view/93587

Description

This sample shows you how you can design your n-tier MVC web application. This project also conclude test project and code analysis and code metrics which have been put in report folder.this sample is using Entity framework 6 with database first approach.Futher the project description and every deatils is provided inside the project file.This sample is also using how to use custom htmlhelper method to design your own custom control.

 

Project is organized using five different solution folders inside visual studio solution folder. This project solution is using nugget package to managing all the framework level dependencies. All package configuration is inside the project directory itself.

DAL – Data Access Layer
Model
Presentation
Reports
Test
Presentation folder has main MVC webapp project. All layer and project directory inforamtion is provided into project structure folder.



Code snippet for Custom htmlhelper method.

 

C#
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
