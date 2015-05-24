using Chat.Service.Entity;
using Chat.Service.Models.Enums;
using Chat.Service.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServicePlace.Utils.Enums;

namespace Chat.Service.APIControllers
{
    public class MemberApprovelController : BaseApiController
    {
        public object MemberApproval(MemberApprovalRequestModel model)
        {
            Group_Member groupMember = dbContext.Group_Member.FirstOrDefault(c => c.GrpMemid == model.MemberId && c.GrpID == model.GrpID);
            if (groupMember == null)
            {
                return FailureResponse(ErrorCode.ERROR100,"No Group or GroupMember found.");
            }
            groupMember.Status = (int)model.MemberStatus;

            dbContext.SaveChanges();
            return SuccessResponse(true);
        }

    }
}
