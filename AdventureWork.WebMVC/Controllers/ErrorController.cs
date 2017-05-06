using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWork.WebMVC.Controllers
{
    public class ErrorController : Controller
    {
        //General purpose action for showing URL not found when user 
        //tries to navigate on invalid URL.

        public ActionResult NotFound()
        {
            return View();
        }

    }
}
