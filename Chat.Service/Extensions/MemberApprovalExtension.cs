using AutoMapper;
using Chat.Service.Entity;
using Chat.Service.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Service.Extensions
{
    public static class MemberApprovalExtension
    {
        public static Group_Member ToEntity(this MemberApprovalResponseModel model)
        {
            return Mapper.Map<MemberApprovalResponseModel, Group_Member>(model);
        }
        
    }
}