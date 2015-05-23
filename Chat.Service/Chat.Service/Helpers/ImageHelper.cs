using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Chat.Service.Helpers
{
    public static class ImageHelper
    {
        public static string DomainUrl
        {
            get { return ConfigurationManager.AppSettings["DomainUrl"]; }
        }
    }
}