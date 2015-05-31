using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Chat.Service.Entity;
using Chat.Service.Helpers;
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
            objuser.PhoneType = model.Mobtype;
            objuser.Status = "0";
            objuser.UserName = model.Name;

            objuser.OTP = CommonHelper.GetRandomKey(4);
            objuser.OTPStatus = 0;
            objuser.OPTDate = System.DateTime.Now;
            dbContext.User_Master.Add(objuser);
            objuser.DeptID = model.Deptid;
            //objuser.DOB = model.Dob;
            dbContext.SaveChanges();
            return SuccessResponse(new RegistrationResponseModel() { UserId = objuser.UserID, Otp = objuser.OTP, Status = 1 });
        }


        public object CheckAppInstall(AppInstallRequestModel model)
        {
            List<User_Master> userMasters =
                dbContext.User_Master.Where(x => model.MobileNumbers.Contains(x.MobileNo)).ToList();
            List<AppInstallResponseModel> appInstallResponseModels = new List<AppInstallResponseModel>();
            appInstallResponseModels = userMasters.Select(x => new AppInstallResponseModel()
                                                            {
                                                                MobileNumber = x.MobileNo,
                                                                IsInstall = true
                                                            }).ToList();

            List<string> unInstallModileNumber =
                model.MobileNumbers.Except(appInstallResponseModels.Select(x => x.MobileNumber)).ToList();

            foreach (var strMobileNumber in unInstallModileNumber)
            {
                appInstallResponseModels.Add(new AppInstallResponseModel() { MobileNumber = strMobileNumber ,IsInstall = false});
            }

            return SuccessResponse(appInstallResponseModels);
        }
    }
}
