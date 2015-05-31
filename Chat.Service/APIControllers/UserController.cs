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
using Chat.Service.Extensions;

namespace Chat.Service.APIControllers
{
    public class UserController : BaseApiController
    {
        public object Register(RegisterRequestModel model)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            User_Master objuser = new User_Master();
            objuser.CatID = 3;
            objuser.MobileNo = model.Phone;
            objuser.PhoneType = model.Mobtype;
            objuser.Status = "0";
            objuser.UserName = model.Name;
            objuser.Phone = model.Mobileid;
            objuser.Gender = model.Gender;
            objuser.OTP = CommonHelper.GetRandomKey(4);
            objuser.DOB = model.Dob;
            objuser.OTPStatus = 0;
            objuser.OPTDate = System.DateTime.Now;
            dbContext.User_Master.Add(objuser);
            objuser.DeptID = model.Deptid;
            //objuser.DOB = model.Dob;
            dbContext.SaveChanges();
            Helpers.CommonHelper.SendSMS(objuser.MobileNo, "Your OTP for iFirst is " + objuser.OTP + ". OTP is Valid till 24 hours");
            return SuccessResponse(new RegistrationResponseModel() { UserId = objuser.UserID, Otp = objuser.OTP, Status = 1 });
        }

        public object CheckOTP(OtpConfirmRequestModel model)
        {
            OTPConfirmRespondModel objresponce = new OTPConfirmRespondModel();
            var userdata = dbContext.User_Master.Where(d => d.MobileNo == model.MobileNumber && d.OTP == model.OTPCode).FirstOrDefault();
            if (userdata!=null)
            {
                TimeSpan hour = System.DateTime.Now.Subtract(userdata.OPTDate.Value);
                if (hour.Hours>24)
                {
                    objresponce.Result = false;
                    objresponce.message = "OTP is Expired Please Re-Generate";
                    
                }
                else
                {
                    objresponce.Result = true;
                    userdata.OTPStatus = 1;
                    dbContext.SaveChanges();
                }


                
            }
            else
            {
                objresponce.Result = false;
                objresponce.message = "No OTP Found you want to re-generate?";
            }
            return objresponce;

        }

        public object ReGenerateOTP(string Mobile)
        {
            var userdata = dbContext.User_Master.Where(d => d.MobileNo == Mobile).FirstOrDefault();
            userdata.OTPStatus = 0;
            userdata.OTP = CommonHelper.GetRandomKey(4);
            userdata.OPTDate = System.DateTime.Now;
            dbContext.SaveChanges();
            Helpers.CommonHelper.SendSMS(userdata.MobileNo, "Your OTP for iFirst is " + userdata.OTP + ". OTP is Valid till 24 hours");
            return userdata.OTP;

            
        }

        public object CheckAppInstall(AppInstallRequestModel model)
        {
            string[] mobilenumbers = model.MobileNumbers.Split(',');
            List<User_Master> userMasters =
                dbContext.User_Master.Where(x => mobilenumbers.Contains(x.MobileNo)).ToList();
            List<AppInstallResponseModel> appInstallResponseModels = new List<AppInstallResponseModel>();
            appInstallResponseModels = userMasters.Select(x => new AppInstallResponseModel()
                                                            {
                                                                MobileNumber = x.MobileNo,
                                                                IsInstall = true,
                                                                UserName=x.UserName
                                                            }).ToList();

            List<string> unInstallModileNumber =
                mobilenumbers.Except(appInstallResponseModels.Select(x => x.MobileNumber)).ToList();

            foreach (var strMobileNumber in unInstallModileNumber)
            {
                appInstallResponseModels.Add(new AppInstallResponseModel() { MobileNumber = strMobileNumber ,IsInstall = false});
            }

            return SuccessResponse(appInstallResponseModels);
        }
        public object GetDepartments()
        {
            List<DepartmentResponseModel> lstDepetlist = dbContext.Department_Master.Where(d => d.IsDeleted == 0).ToList().Select(x=>x.ToModel()).ToList();
            return SuccessResponse(lstDepetlist);
            
        }
    }
}
