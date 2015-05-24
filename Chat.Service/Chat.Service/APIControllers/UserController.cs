using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Chat.Service.Entity;
using Chat.Service.Models.Request;
using Chat.Service.Models.Response;

namespace Chat.Service.APIControllers
{
    public class UserController : BaseApiController
    {
        public object Register(RegisterRequestModel model)
        {
            User_Master objuser = new User_Master();
            objuser.CatID = 3;
            objuser.MobileNo = model.Phone;
            objuser.MobileNo = model.Mobileid;
            //  objuser.PhoneType = mobtype;
            objuser.Status = "0";
            objuser.UserName = model.Name;
            //objuser.OTP = Common.GetRandomKey(4);
            //objuser.OTPStatus = 0;
            //objuser.OPTDate = System.DateTime.Now;
            dbContext.User_Master.Add(objuser);
            // objuser.d = deptid;
            //objuser.DOB = DOB;
            dbContext.SaveChanges();
            return SuccessResponse(new RegistrationResponseModel());
        }
    }
}
