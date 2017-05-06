using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdventureWork.Data.Infrastructure.Interface;
using AdventureWork.Data.Infrastructure.Repository;
using AdventureWork.WebMVC.ViewModel;
using AdventureWork.WebMVC.Common;
using AdventureWork.Domain.Model;


namespace AdventureWork.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private readonly IRepository productRepository;
        public HomeController(IRepository _productRepository)
        {
            this.productRepository = _productRepository;
        }


        /// <summary>
        /// List of all Poduct Name
        /// </summary>
       
        //[OutputCache(Duration=60)]
        public ActionResult Index()
        {
           
            var products = productRepository.GetAllProduct();
            var productview = products.Select(s => new HomePageViewModel
            {
                productId = s.ProductID,
                productName = s.Name,
                selected = s.MakeFlag
            }).ToList();

            
            return View(productview);
        }

        
        /// <summary>
        /// Loading Image in thumbnail on Homepage
        /// </summary>
       
        [OutputCache(Duration=300)]
        public ActionResult LoadImage()
        {
            //Image img;
            List<HomePageThumbnailPhoto> thumbnailPhotos = new List<HomePageThumbnailPhoto>();
            List<ProductPhoto> photos = productRepository.GetAllImage();
            HomePageThumbnailPhoto thmb = new HomePageThumbnailPhoto();
            int i = 0;
                foreach (var item in photos)
                {
                   
                    thumbnailPhotos.Add(new HomePageThumbnailPhoto
                    {
                        PhotoId = item.ProductPhotoID,
                        Photo = item.LargePhoto,
                        PhotoName = thmb.getPhotoName(item.ThumbnailPhotoFileName),
                        Description = productRepository.GetDescription(i)
                    }
                    );
                    i++;
                }
               
            
            return PartialView(thumbnailPhotos);
        }


        /// <summary>
        /// Search for perticular item in database where search button is presses from UI
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        
        public ActionResult Search(string searchText)
        {
            var product = productRepository.GetAllProductBySearchString(searchText);
            var productview = product.Select(s => new HomePageViewModel
            {
                productId = s.ProductID,
                productName = s.Name,
                selected = s.MakeFlag
            }).ToList();

            return PartialView(productview);
        }

        /// <summary>
        /// Get bookmark Item from database
        /// </summary>
        /// <returns></returns>
        
        public ActionResult GetBookmarkItems()
        {
            var products = productRepository.GetBookmarkProduct();
            var bookmarkProductview = products.Select(s => new HomePageViewModel
            {
                productId =s.ProductID,
                productName = s.Name,
                selected = s.MakeFlag
            }).ToList();

            return View(bookmarkProductview);
        }

        [OutputCache(Duration=120)]
        public ActionResult GetCompanyLogo()
        {
            ViewBag.ImageData = Utility.ConvertImageToByteArray();
            return PartialView();
        }


        //Add item into bookmarks
        //[NonActionAttribute]
        public void AddItemInBookmark(int id)
        {
            productRepository.AddInBookmark(id);
        }


        //Remove Item in bookmarks
        public void RemoveItemFromBookmark(int id)
        {
            productRepository.RemoveFromBookmarks(id);
        }
    }
}
