using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Chat.Service.Entity;
using Chat.Service.Helpers;
using Chat.Service.Models.Response;

namespace Chat.Service.Extensions
{
    public static class ChatExtension
    {
        public static ChatResponseModel ToModel(this ChatTab entity)
        {
            ChatResponseModel model = Mapper.Map<ChatTab, ChatResponseModel>(entity);
            model.ImageUrl = model.ImageUrl.ToDominImage();
            model.AudioUrl = model.AudioUrl.ToDominImage();
            model.VideoUrl = model.VideoUrl.ToDominImage();
            model.FileUrl = model.FileUrl.ToDominImage();
            return model;
        }
    }
}