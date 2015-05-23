using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Chat.Service.Models.Request;

namespace Chat.Service.APIControllers
{
    public class ChatController : BaseApiController
    {
        public object CheckChatConfigration(ChatRequest model)
        {
            return SuccessResponse(true);
        }
    }
}
