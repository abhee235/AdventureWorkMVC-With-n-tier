using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace AdventureWork.WebMVC.ViewModel
{
    public class HomePageThumbnailPhoto
    {
        public int PhotoId { get; set; }
        public byte[] Photo { get; set; }
        public string PhotoName { get; set; }
        public string Description { get; set; }


        public string getPhotoName(string photoName)
        {
            string[] photonameArr = photoName.Remove(photoName.IndexOf("small")).Split('_');
            return photoName = string.Join(" ",photonameArr);
        }
    }
}