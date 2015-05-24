using Chat.Service.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chat.Service.Models.Enums;

namespace Chat.Service.Models.Request
{
    public class MemberApprovalRequestModel : BaseRequestModel
    {
        public int GrpID { get; set; }
        public MemberStatus MemberStatus { get; set; }
        public int MemberId { get; set; }
    }
}