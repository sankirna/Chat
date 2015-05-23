using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Service.Models.Common
{
    /// <summary>
    /// Represents service response
    /// </summary>
    public class ServiceResponse<T>
    {
        public Response<T> Response { get; set; }

        public ServiceResponse(T response, bool succsess)
        {
            Response = new Response<T>(response, succsess);
        }
    }
}