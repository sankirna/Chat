using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Service.Models.Request
{
    public class OtpConfirmRequestModel
    {
        public string MobileNumber { get; set; }
        public string OTPCode { get; set; }
    }
}