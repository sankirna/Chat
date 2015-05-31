using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using Chat.Service.Models.Common;
using ServicePlace.Utils.Enums;

namespace Chat.Service.Filters
{
    public class HandleApiExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            //Caputure error in log formate
            //LogUtility.HandleAndLogException(context.Exception, context.ActionContext.ControllerContext);

            HttpStatusCode status = HttpStatusCode.OK;

            FailureResponse failureResponse = new FailureResponse(ErrorCode.ERROR100, context.Exception.ToString());
            ServiceResponse<FailureResponse> serviceResponse = new ServiceResponse<FailureResponse>(failureResponse, false);

            // create a new response and attach our ApiError object
            // which now gets returned on ANY exception result
            var errorResponse = context.Request.CreateResponse(status, serviceResponse);
            context.Response = errorResponse;

            //base.OnException(context);
        }

    }
}