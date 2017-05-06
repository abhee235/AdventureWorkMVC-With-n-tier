using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace AdventureWork.WebMVC.Common
{
    public static class Utility
    {

        // Local resources can not be displaed in web browser through IIS Express.
        // Taking logo from content folder and loading this logo on wwebpage through call this utility method.
        //This method is only developed for development environment.


        public static byte[] ConvertImageToByteArray()
        {
            using (MemoryStream stream = new MemoryStream())
            {

                string path = AppDomain.CurrentDomain.BaseDirectory;
                Image img = Image.FromFile(string.Concat(path + "Content\\AdventureTransparent.png"));
                img.Save(stream, ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }

    }
}