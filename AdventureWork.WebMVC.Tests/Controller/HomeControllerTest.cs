using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureWork.WebMVC.Controllers;
using System.Collections.Generic;
using AdventureWork.WebMVC.ViewModel;
using System.Web.Mvc;
using AdventureWork.Data.Infrastructure.Repository;

namespace AdventureWork.WebMVC.Tests.Controller
{
    [TestClass]
    public class HomeControllerTest : IDisposable
    {
        private static ProductRepository _repository = new ProductRepository();
        private readonly HomeController controller = new HomeController(_repository);
        private bool disposed = false;

        [TestMethod]
        public void index()
        {

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result.Model);


        }

        [TestMethod]
        public void Search()
        {
            PartialViewResult result = controller.Search("Ball") as PartialViewResult;
            Assert.IsNotNull(result.Model);

        }

        public void Dispose()
        {
            if (!disposed)
            {
                Dispose(true);
            }
           
           
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if ( controller!= null)
                {
                  
                    controller.Dispose();
                }
                disposed = true;
               
                if (disposing)
                {
                    GC.SuppressFinalize(this);
                }
            }
        }
    }
}
