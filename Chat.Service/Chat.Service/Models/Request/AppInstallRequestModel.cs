using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chat.Service.Models.Common;

namespace Chat.Service.Models.Request
{
    public class AppInstallRequestModel : BaseRequestModel
    {
        public List<string> MobileNumbers { get; set; }
    }
}