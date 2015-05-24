using Chat.Service.Entity;
using Chat.Service.Models.Enums;
using Chat.Service.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chat.Service.APIControllers
{
    public class MemberApprovelController : BaseApiController
    {
        public object MemberApproval(MemberApprovalRequestModel model)
        {
            Group_Member groupMember = dbContext.Group_Member.SingleOrDefault(c => c.GrpMemid == model.MemberId);
            groupMember.Status = Convert.ToInt16(MemberStatus.Approved);

            dbContext.SaveChanges();
            return SuccessResponse(true);
        }

    }
}
