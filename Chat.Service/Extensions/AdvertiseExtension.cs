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
    public static class AdvertiseExtension
    {
        public static GetAdvertiseResponseModel ToModel(this Advertise entity)
        {
            GetAdvertiseResponseModel model = Mapper.Map<Advertise, GetAdvertiseResponseModel>(entity);
            model.ImagePath = string.Format("{0}{1}", ImageHelper.DomainUrl, model.ImagePath);
            return model;
        }
    }
}