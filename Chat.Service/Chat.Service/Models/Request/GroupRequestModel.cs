using Chat.Service.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Service.Models.Request
{
    public class GroupRequestModel : BaseRequestModel
    {
        public GroupRequestModel()
        {
            GroupMemberModel = new MemberRequestModel();
        }
        public string GroupName { get; set; }
        public string GIplmg { get; set; }
        public int GrpAdmin { get; set; }
        public MemberRequestModel GroupMemberModel { get; set; }
        
    }

    public class MemberRequestModel : BaseRequestModel
    {
        public List<int> MembersId { get; set; }
        public int GroupId { get; set; }
     
    }
}