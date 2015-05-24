using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chat.Service.Models.Common;

namespace Chat.Service.Models.Request
{
    public class CreateChatRequest : BaseRequestModel
    {
        public int SenderId { get; set; }
        public string RecieverMobileNumber { get; set; }
        public string Message { get; set; }
    }
}