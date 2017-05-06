using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWork.Data.Infrastructure.Interface;
using AdventureWork.Data.Context;
using System.Drawing;
using System.IO;

namespace AdventureWork.Data.Infrastructure.Repository
{
    public class ProductRepository : IRepository,IDisposable
    {
        private List<string> descriptionList = new List<string>(); 
        private readonly AdventureWorksEntities context = new AdventureWorksEntities();

        public List<Domain.Model.Product> GetAllProduct()
        {
            
                return context.Products.AsEnumerable().ToList();
            
        }

        public List<Domain.Model.ProductPhoto> GetAllImage()
        {

           // List<Domain.Model.ProductPhoto>
                var productPhotos = context.ProductPhotos.Distinct();
            return productPhotos.AsEnumerable().Skip(5).Take(3).ToList();
        }

        public List<Domain.Model.Product> GetAllProductBySearchString(string searchString)
        {

            return context.Products.Where(i => i.Name.Contains(searchString)).ToList();

        }



        public List<Domain.Model.Product> GetBookmarkProduct()
        {
            return context.Products.Where(s => s.MakeFlag == true).AsEnumerable().ToList();
        }


        public string GetDescription(int i)
        {
            return getProductDescription(i);
        }

        private string getProductDescription(int no)
        {
            if (descriptionList.Count() == 0)
            {
                descriptionList = context.ProductDescriptions.Distinct().Where(i => i.Description.Length > 80).Take(3).Select(s => s.Description).ToList();
            }

            return descriptionList.ElementAt(no);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                    context.Dispose();
            }
        }


        public void AddInBookmark(int id)
        {
            var flag = context.Products.Find(id);
            if (flag.MakeFlag == false)
            {
                flag.MakeFlag = true;
                context.SaveChanges();
            }
        }


        public void RemoveFromBookmarks(int id)
        {
            var flag = context.Products.Find(id);
            if (flag.MakeFlag == true)
            {
                flag.MakeFlag = false;
                context.SaveChanges();
            }
        }
    }

}
