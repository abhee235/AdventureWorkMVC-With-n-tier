using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureWork.Data.Infrastructure.Interface;
using AdventureWork.Data.Infrastructure.Repository;


namespace AdventureWork.IntegrationTest
{
    [TestClass]
    public class DataAccessAndRepository : IDisposable
    {

        private readonly IRepository productRepository = new ProductRepository();

        [TestMethod]
        public void GetListOfProduct()
        {
            var productlist = productRepository.GetAllProduct();
            Assert.IsTrue(productlist.Count > 0);
        }

        [TestMethod]
        public void GetImage()
        {
            var images = productRepository.GetAllImage();
            Assert.IsNotNull(images);
        }

        [TestMethod]
        public void bookmarkItem()
        {
            var item = productRepository.GetBookmarkProduct();
            Assert.IsTrue(item.Count > 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (productRepository != null)
                    productRepository.Dispose();
            }
        }
    }
}
