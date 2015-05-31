using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Service.Models.Response
{
    public class RegistrationResponseModel
    {
        public int UserId    { get; set; }
        public string Otp { get; set; }
        public  int Status { get; set; }
    }
}