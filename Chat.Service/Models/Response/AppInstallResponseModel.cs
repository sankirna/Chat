using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Service.Models.Response
{
    public class AppInstallResponseModel
    {
        public string MobileNumber { get; set; }
        public bool IsInstall { get; set; }
        public string UserName { get; set; }
    }
}