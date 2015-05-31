using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Chat.Service.Entity;
using Chat.Service.Extensions;
using Chat.Service.Helpers;
using Chat.Service.Models.Enums;
using Chat.Service.Models.Request;
using ServicePlace.Utils.Enums;

namespace Chat.Service.APIControllers
{
    public class ChatController : BaseApiController
    {
        public object CheckChatConfigration(ChatRequest model)
        {
            return SuccessResponse(true);
        }

        public object CreateChat(CreateChatRequest model)
        {
            User_Master reciever = dbContext.User_Master.FirstOrDefault(x => x.MobileNo == model.ReceiverMobileNumber);
            if (reciever == null)
            {
                return FailureResponse(ErrorCode.ERROR100, "No Reciever Exists");
            }

            var chatTab = new ChatTab();
            chatTab.SenderId = model.SenderId;
            chatTab.ReceiverID = reciever.UserID;
            chatTab.Message = model.Message;
            chatTab.Status = (int)ChatStatus.Unread;
            chatTab.MsgType = (int)MessageType.Text;
            chatTab.DateCreated = DateTime.Now;
            //chatTab.IsDeleted = false;
            dbContext.ChatTabs.Add(chatTab);
            dbContext.SaveChanges();

            return SuccessResponse(true);
        }


        public object ChatList(ChatListRequestModel model)
        {
            User_Master reciever = dbContext.User_Master.FirstOrDefault(x => x.MobileNo == model.ReceiverMobileNumber);
            if (reciever == null)
            {
                return FailureResponse(ErrorCode.ERROR100, "No Reciever Exists");
            }

            DateTime startDate = model.StartDate.ToDateTime();
            DateTime endDate = model.EndDate.ToDateTime();

            var chats = dbContext.ChatTabs.Where(x => x.ReceiverID == reciever.UserID
                                                            && x.SenderId == model.SenderId
                                                            )
                                                            .OrderByDescending(x => x.DateCreated)
                                                            .Skip((model.PageNo - 1) * model.PageSize)
                                                            .Take(model.PageSize);
            //if (!string.IsNullOrEmpty(model.StartDate) && startDate !=new DateTime())
            //{
            //    chats = chats.Where(x => x.DateCreated >= startDate);
            //}
            //if (!string.IsNullOrEmpty(model.EndDate) && endDate != new DateTime())
            //{
            //    chats = chats.Where(x => x.DateCreated <= endDate);
            //}
            var chatReponses = chats.ToList()
                                    .Select(x => x.ToModel())
                                    .ToList();

            return SuccessResponse(chatReponses);
        }


        public async Task<object> UploadImage()
        {
            string tempPath = HttpContext.Current.Server.MapPath("~/Content/UploadImage");
            bool isTempExists = System.IO.Directory.Exists(tempPath);

            if (!isTempExists)
                System.IO.Directory.CreateDirectory(tempPath);

            MyMultipartFormDataStreamProvider stream = new MyMultipartFormDataStreamProvider(tempPath);

            await RequestContext.Request.Content.ReadAsMultipartAsync(stream);



            string savePath = string.Empty;

            if (!string.IsNullOrEmpty(stream.strFilename))
            {
                string childUploadImagePath = HttpContext.Current.Server.MapPath(string.Format("~/Content/UploadImage/{0}", 10));

                //Check and create directory for child
                bool isExists = System.IO.Directory.Exists(childUploadImagePath);

                if (!isExists)
                    System.IO.Directory.CreateDirectory(childUploadImagePath);

                // Use Path class to manipulate file and directory paths. 
                string sourceFile = System.IO.Path.Combine(tempPath, stream.strFilename);
                string destFile = System.IO.Path.Combine(childUploadImagePath, stream.strFilename);


                // To copy a file to another location and  
                // overwrite the destination file if it already exists.
                System.IO.File.Move(sourceFile, destFile);

            }

            return SuccessResponse(true); ;
        }
    }
}
