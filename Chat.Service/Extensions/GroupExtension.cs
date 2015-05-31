using AutoMapper;
using Chat.Service.Entity;
using Chat.Service.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Service.Extensions
{
    public static class GroupExtension
    {
        public static Group_Master ToEntity(this GroupResponseModel model)
        {
            return Mapper.Map<GroupResponseModel, Group_Master>(model);
        }
    }
}