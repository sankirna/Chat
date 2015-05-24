using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chat.Service.Models.Common;

namespace Chat.Service.Models.Request
{
    public class ChatListRequestModel : BaseRequestModel
    {
        public int ReciverId { get; set; }
        public string SenderMobleNjmber { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}