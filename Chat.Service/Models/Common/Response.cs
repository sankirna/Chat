using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Service.Models.Common
{
    /// <summary>
    /// Represents response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }

        public Response(T data, bool success)
        {
            Data = data;
            Success = success;
        }
    }
}