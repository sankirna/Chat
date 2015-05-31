using System;
using System.ComponentModel;
namespace ServicePlace.Utils.Enums
{
    /// <summary>
    /// Error Codes
    /// </summary>
    public enum ErrorCode
    {
        #region Generic
        /// <summary>
        /// Generic for generic
        /// </summary>
        [Description("Generic for generic")]
        ERROR100 = 100,

        /// <summary>
        /// Exception
        /// </summary>
        [Description("Exception")]
        ERROR101 = 101,

        /// <summary>
        /// No data available.
        /// </summary>
        [Description("No data available.")]
        ERROR102 = 102,

        /// <summary>
        /// Invalid model.
        /// </summary>
        [Description("Invalid model.")]
        ERROR103 = 103,

        /// <summary>
        /// Invalid city id.
        /// </summary>
        [Description("Invalid city id.")]
        ERROR104 = 104,

        /// <summary>
        /// Invalid restaurant id.
        /// </summary>
        [Description("Invalid restaurant id.")]
        ERROR105 = 105,

        /// <summary>
        /// Address not found.
        /// </summary>
        [Description("Address not found.")]
        ERROR106 = 106,

        #endregion

    }

    public static class ErrorCodeClass
    {
        /// <summary>
        /// Thwo in implemented exception
        /// </summary>
        /// <param name="errorMessage">Error message</param>
        /// <returns>Exception string</returns>
        public static Exception MyException(ErrorCode code, string errorMessage = "")
        {
            return new NotImplementedException(errorMessage) { HelpLink = code.ToString() };
        }
    }
}
