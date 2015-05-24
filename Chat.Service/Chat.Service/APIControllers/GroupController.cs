using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chat.Service.Extensions;
using ServicePlace.Utils.Enums;
using Chat.Service.Models.Request;
using Chat.Service.Entity;
using Chat.Service.Models.Enums;

namespace Chat.Service.APIControllers
{
    public class GroupController : BaseApiController
    {
        public object Group(GroupRequestModel model)
        {

            Group_Master groupMaster = new Group_Master();
            groupMaster.GroupName = model.GroupName;
            groupMaster.GIplmg = model.GIplmg;
            groupMaster.GrpAdmin = model.GrpAdmin;
            groupMaster.IP = model.IP;
            groupMaster.CreatedDate = DateTime.Now;
            groupMaster.IsDeleted = 0;
            dbContext.Group_Master.Add(groupMaster);
            dbContext.SaveChanges();
            model.GroupMemberModel.GroupId = groupMaster.GrpID;
            GroupMembers(model.GroupMemberModel);

            return SuccessResponse(true);
        }


        public object GroupMembers(MemberRequestModel modelGroupMember)
        {
            foreach (int grpMember in modelGroupMember.MembersId)
            {
                Group_Member groupMember = new Group_Member();
                groupMember.GrpID = modelGroupMember.GroupId;
                groupMember.GrpMemid = grpMember;
                groupMember.Status = (int?)MemberStatus.UnApproved;
                groupMember.CreatedDate = DateTime.Now;
                groupMember.IsDeleted = 0;
                dbContext.Group_Member.Add(groupMember);

            }
            dbContext.SaveChanges();
            return SuccessResponse(true);
        }
    }
}
