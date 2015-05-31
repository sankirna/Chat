using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chat.Service.Models.Common;

namespace Chat.Service.Models.Request
{
    public class RegisterRequestModel:BaseRequestModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Gender { get; set; }
        public int Deptid { get; set; }
        public DateTime Dob { get; set; }
        public string Mobileid { get; set; }
        public int Mobtype { get; set; }
    }
}