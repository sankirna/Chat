using Chat.Service.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Service.Models.Request
{
    public class MemberApprovalRequestModel : BaseRequestModel
    {
        public int GrpID { get; set; }
        public string GroupName { get; set; }
        public int MemberId { get; set; }
    }
}