
///   PARSING ERROR MESSAGE
///   var statusCode = exc.Data.Keys.Cast<string>().First();  // ERROR CODE
///   var statusMessage = exc.Data[statusCode];  // MESSAGE

using System;

namespace DynamixLogger.Utilities
{
    internal class ErrorCode
    {
        public const string CDX_NO_VALUE = "3434";

        // CASTING ERROR LEVELS
        public const string CDX_SQL_CAST_FAIL = "4434";
        public const string CDX_FILE_CAST_FAIL = "4435";
        public const string CDX_BASE_CAST_FAIL = "4436";
        public const string CDX_VALUE_READ_ERROR = "5457";
    }



    internal class ErrorGenerator
    {
        internal static Exception Generate(string errorCode, string errorPoint = "")
        {
            string message = GetMessage(errorCode);

            if (errorPoint != string.Empty)
            {
                message += "; " + errorPoint;
                message = message.Trim();
            }

            var ex = new Exception(string.Format(" ( CODE-{1} ) : {0} ", message, errorCode));
            ex.Data.Add(errorCode, message);

            return ex;
        }

        /// <summary>
        /// Get Error Message Based On Message Code
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        private static string GetMessage(string errorCode)
        {
            string message = string.Empty;
            switch (errorCode)
            {
                case ErrorCode.CDX_NO_VALUE: message = Messages.NULL_VALUE_EXCEPTION; break;

                case ErrorCode.CDX_SQL_CAST_FAIL: message = Messages.CAST_SQLLOGINFO_EXPECTED; break;

                case ErrorCode.CDX_FILE_CAST_FAIL: message = Messages.CAST_FILELOGINFO_EXPECTED; break;

                case ErrorCode.CDX_BASE_CAST_FAIL: message = Messages.CAST_BASELOGINFO_EXPECTED; break;

                case ErrorCode.CDX_VALUE_READ_ERROR: message = Messages.CONNECTION_STRING_READ_ERROR; break;

                default: message = string.Empty; break;
            }

            return message;
        }

    }

}
