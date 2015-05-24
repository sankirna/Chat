using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chat.Service.Models.Enums;

namespace Chat.Service.Models.Response
{
    public class ChatResponseModel
    {
        public int ChatId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Message { get; set; }
        public string AudioUrl { get; set; }
        public string VideoUrl { get; set; }
        public string ImageUrl { get; set; }
        public string FileUrl { get; set; }
        public MessageType MsgType { get; set; }
        public ChatStatus Status { get; set; }
        public string DateCreated { get; set; }
    }
}