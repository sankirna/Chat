using System;
using System.Web.Http;
using System.Web.Mvc;
using Chat.Service.Areas.HelpPage.Models;

namespace Chat.Service.Areas.HelpPage.Controllers
{
    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    public class HelpController : Controller
    {
        public HelpController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        public HelpController(HttpConfiguration config)
        {
            Configuration = config;
        }

        public HttpConfiguration Configuration { get; private set; }

        public ActionResult Index()
        {
           Helpers.CommonHelper.SendSMS("9722972611", "Your OTP for iFirst is 0347. OTP is Valid till 24 hours");
          //  String r = "APA91bF8UL5K2vxrq0YNKnDtK5fnVxD2TLrBGt1uZZ55MBn4bNypWd5Y94PdUdOsDHjyzk1PQTHbeZgpBVoDdyS1zdV-Sc5WYJbMT7C1eizAlB5tO7QnMFVmYI4_vvk-_7TmsdiDTy5o,APA91bEYM1DC5eVKJBiIf6gity7HTntxrxsBX4tQiEUEKkHRJ2KqdWBmF9usqODOCqWHXdfdZrPh3ba_s_NRwKvY1Bd-7dvb63luXxQFHU0TTRcrLSHEqS62Mx54O-hzOCb8XX0lCxNX";
            //string[] rg= r.Split(',');

//            Helpers.CommonHelper.SendGCM(rg,"Test","C","Hello","HArdik","h","11","15","a");
           
            return View(Configuration.Services.GetApiExplorer().ApiDescriptions);
        }

        public ActionResult Api(string apiId)
        {
            if (!String.IsNullOrEmpty(apiId))
            {
                HelpPageApiModel apiModel = Configuration.GetHelpPageApiModel(apiId);
                if (apiModel != null)
                {
                    return View(apiModel);
                }
            }

            return View("Error");
        }
    }
}