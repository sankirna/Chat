using Chat.Service.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Service.Models.Request
{
    public class GroupMemberRequestModel : BaseRequestModel
    {       
        public int GrpID { get; set; }
        public int GrpMemid { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> IsDeleted { get; set; }
    }
}