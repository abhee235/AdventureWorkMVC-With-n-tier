using AdventureWork.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWork.Data.Infrastructure.Interface
{
    public interface IRepository
    {
        /// <summary>
        /// Get all Product.
        /// </summary>
        /// <returns>List of Product</returns>
        
        List<Product> GetAllProduct();

        /// <summary>
        /// Load Image in Layout when page is loaded.
        /// </summary>
        /// <returns>List of Images</returns>
        
        List<ProductPhoto> GetAllImage();

        /// <summary>
        /// Search the specified string 
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        
        List<Product> GetAllProductBySearchString(string searchString);

        /// <summary>
        /// All bookmarked product 
        /// </summary>
        /// <returns></returns>
        
        List<Product> GetBookmarkProduct();

        /// <summary>
        /// Get description of Image. Ony for internal use 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        
        string GetDescription(int i);


        //making the flag 1 in product table.
        void AddInBookmark(int id);

        //setting the make flag value to zero in product table
        void RemoveFromBookmarks(int id);

        /// <summary>
        /// Dispose object
        /// </summary>
        /// 

       
        void Dispose();

        
    }
}
