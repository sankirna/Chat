using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chat.Service.Helpers;

namespace Chat.Service.Extensions
{
    public static class ImageExtension
    {
        public static string ToDominImage(this string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                return string.Empty;
            }
            return string.Format("{0}{1}", ImageHelper.DomainUrl, imagePath);
        }
    }
}