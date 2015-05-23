using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Controllers;
using Chat.Service.Entity;
using Chat.Service.Models.Common;
using ServicePlace.Utils.Enums;

namespace Chat.Service.APIControllers
{
    public class BaseApiController : ApiController
    {
        #region "Protected Member(s)"

        protected HttpControllerContext RequestContext;
        protected string ActionName = string.Empty;
        protected string ControllerName = string.Empty;
        protected ChatContext dbContext = new ChatContext();


        #endregion

        #region "Private Member(s)"

        /// <summary>
        /// Gets or sets response for webservice call from javascript
        /// </summary>
        private object Response { get; set; }

        #endregion

        #region "Public Member(s)"

        /// <summary>
        /// set Action and Controller Name from Current Controller Context
        /// </summary>
        /// <param name="requestContext"></param>
        protected override void Initialize(HttpControllerContext requestContext)
        {
            this.RequestContext = requestContext;

            ActionName = requestContext.RouteData.Values["action"].ToString();
            ControllerName = requestContext.RouteData.Values["controller"].ToString();
        }

        /// <summary>
        /// Process exception generated during function process or user generated error process
        /// </summary>
        /// <param name="errorMessage">Error message</param>
        /// <returns>Exception string</returns>
        protected object FailureResponse(Exception ex, bool? IsSupress = null, bool? IsErrorMessageShow = null)
        {
            // Log for failure response

            FailureResponse failureResponse = new FailureResponse(ex, IsSupress, IsErrorMessageShow);

            if (failureResponse.ErrorCode != ErrorCode.ERROR100)
            {

            }
            else
            {

            }

            return ServiceResponse(failureResponse, false);
        }

        /// <summary>
        /// Gives service success response
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="data">Entity</param>
        protected object SuccessResponse<T>(T data)
        {

            return ServiceResponse(data, true);
        }

        /// <summary>
        /// set Model with success or Failure Response
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="data">Entity</param>
        /// <param name="success">true/false</param>
        private object ServiceResponse<T>(T data, bool success)
        {
            ServiceResponse<T> serviceResponse = new ServiceResponse<T>(data, success);
            Response = serviceResponse;
            return Response;
        }
        #endregion
    }
}
