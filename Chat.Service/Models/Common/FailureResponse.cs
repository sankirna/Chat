using System;
using ServicePlace.Utils.Enums;

namespace Chat.Service.Models.Common
{
    /// <summary>
    /// Represents failure response
    /// </summary>
    public class FailureResponse
    {
        //public ErrorCode EnumErrorCode { get; set; }
        public ErrorCode ErrorCode { get; set; }
        public string Error { get; set; }
        public bool Supress { get; set; }

        /// <summary>
        /// Constructor for Set Failure service response
        /// </summary>
        /// <param name="ex">Exception Object</param>
        public FailureResponse(Exception ex, bool? IsSupress = null, bool? IsErrorMessageShow = null)
        {
            
        }

        public FailureResponse(ErrorCode _errorCode, string _errorMessage)
        {
            ErrorCode = _errorCode;
            Error = _errorMessage;
        }
    }
}
