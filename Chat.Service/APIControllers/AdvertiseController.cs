using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chat.Service.Extensions;
using Chat.Service.Helpers;
using Chat.Service.Models.Request;
using Chat.Service.Models.Response;
using WebGrease.Css.Extensions;

namespace Chat.Service.APIControllers
{
    public class AdvertiseController : BaseApiController
    {
        public object Advertises(GetAdvertiseRequestModel model)
        {

            DateTime nowDateTime = DateTime.Now;
            var advertises = dbContext.Advertises.Where(x =>
                                                                 x.DepartmentId == model.DepartmentId
                                                                 && !x.Deleted
                                                                 && (x.FromDate <= nowDateTime && x.ToDate >= nowDateTime)
                                                                 ).ToList()
                                                                 .Select(x => x.ToModel())
                                                                 .ToList();

            return SuccessResponse(advertises);
        }
    }
}
