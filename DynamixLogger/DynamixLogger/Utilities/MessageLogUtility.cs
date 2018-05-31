using DynamixLogger.Info;
using DynamixLogger.LogStrategy.File;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DynamixLogger.Utilities
{
    internal class MessageLogUtility
    {
        internal static string GenerateLogOnly(FileLogInfo fileLogInfo, bool isException)
        {
            StringBuilder message = new StringBuilder();
            message.Append(Environment.NewLine);

            if (fileLogInfo.EnableDate)
            {
                message.Append("[" + DateTime.Now.ToString(fileLogInfo.LogDateFormat).Trim() + "]" + Environment.NewLine);
                message.Append(FileUtils.Default_LineBreaker + Environment.NewLine);
            }

            if (isException)
                message.Append(FileUtils.HEADER_Message + fileLogInfo.Exception.Message.Trim() + Environment.NewLine);
            else
                message.Append(FileUtils.HEADER_Message + fileLogInfo.LogMessage.Trim() + Environment.NewLine);

            return message.ToString();
        }


        internal static string GenerateLogWithSeverity(FileLogInfo fileLogInfo, bool isException)
        {

            StringBuilder message = new StringBuilder();
            message.Append(Environment.NewLine);

            if (fileLogInfo.EnableDate)
            {
                message.Append("[" + DateTime.Now.ToString(fileLogInfo.LogDateFormat).Trim() + "]" + Environment.NewLine);
                message.Append(FileUtils.Default_LineBreaker + Environment.NewLine);
            }

            message.Append(FileUtils.HEADER_SEVERITY + fileLogInfo.LogLevel.ToString() + Environment.NewLine);

            if (isException)
            {
                message.Append(FileUtils.HEADER_EXCEPTION_MSG + fileLogInfo.Exception.Message.Trim() + Environment.NewLine);
                if (!string.IsNullOrEmpty(fileLogInfo.LogMessage)) message.Append(FileUtils.HEADER_Message_General + fileLogInfo.LogMessage.Trim() + Environment.NewLine);
            }
            else
                message.Append(FileUtils.HEADER_Message + fileLogInfo.LogMessage.Trim() + Environment.NewLine);

            return message.ToString();
        }


        internal static string GenerateFullLogDetail(FileLogInfo fileLogInfo, string source, string eventID)
        {
            StringBuilder message = new StringBuilder();
            message.Append(Environment.NewLine);

            if (fileLogInfo.EnableDate)
            {
                message.Append("[" + DateTime.Now.ToString(fileLogInfo.LogDateFormat).Trim() + "]" + Environment.NewLine);
                message.Append(FileUtils.Default_LineBreaker + Environment.NewLine);
            }

            message.AppendLine(FileUtils.HEADER_APP_UP_TIME + (DateTime.Now - Process.GetCurrentProcess().StartTime).ToString());

            if (!string.IsNullOrEmpty(source)) message.Append(FileUtils.HEADER_SOURCE + source + Environment.NewLine);

            if (!string.IsNullOrEmpty(eventID)) message.Append(FileUtils.HEADER_EVENT_ID + eventID + Environment.NewLine);

            message.Append(FileUtils.HEADER_SEVERITY + fileLogInfo.LogLevel.ToString() + Environment.NewLine);

            message.Append(FileUtils.HEADER_Message + fileLogInfo.LogMessage.Trim() + Environment.NewLine);

            if (!string.IsNullOrEmpty(fileLogInfo.ErrorCode)) message.Append(FileUtils.HEADER_Error_Code + fileLogInfo.ErrorCode.Trim() + Environment.NewLine);

            return message.ToString();

        }

        internal static string GenerateFullLogDetail_EX(FileLogInfo fileLogInfo, string source, string eventID)
        {

            StringBuilder message = new StringBuilder();

            message.Append(Environment.NewLine);

            if (fileLogInfo.EnableDate)
            {
                message.Append("[" + DateTime.Now.ToString(fileLogInfo.LogDateFormat).Trim() + "]" + Environment.NewLine);
                message.Append(FileUtils.Default_LineBreaker + Environment.NewLine);
            }

            message.AppendLine(FileUtils.HEADER_APP_UP_TIME + (DateTime.Now - Process.GetCurrentProcess().StartTime).ToString());

            if (!string.IsNullOrEmpty(source)) message.Append(FileUtils.HEADER_SOURCE + source + Environment.NewLine);

            if (!string.IsNullOrEmpty(eventID)) message.Append(FileUtils.HEADER_EVENT_ID + eventID + Environment.NewLine);

            if (fileLogInfo.Exception.Data.Count > 0)
            {
                var statusCode = fileLogInfo.Exception.Data.Keys.Cast<string>().First();  // ERROR CODE
                var statusMessage = fileLogInfo.Exception.Data[statusCode];  // MESSAGE

                message.Append("Status Code: " + statusCode + Environment.NewLine);
                message.Append("Status Message: " + statusMessage + Environment.NewLine);
            }

            message.Append(FileUtils.HEADER_SEVERITY + fileLogInfo.LogLevel.ToString() + Environment.NewLine);
            message.Append(FileUtils.HEADER_EXCEPTION_CLASS);
            message.Append(GetExceptionTypeStack(fileLogInfo.Exception));
            message.AppendLine(string.Empty);

            message.Append(FileUtils.HEADER_EXCEPTION_MSG);
            message.Append(GetExceptionMessageStack(fileLogInfo.Exception));
            message.AppendLine(string.Empty);

            message.Append(GetExceptionCallStack(fileLogInfo.Exception));

            if (!string.IsNullOrEmpty(fileLogInfo.LogMessage))
                message.Append(FileUtils.HEADER_Message_General + fileLogInfo.LogMessage.Trim() + Environment.NewLine);

            return message.ToString();
        }



        private static string GetExceptionTypeStack(Exception e)
        {
            if (e.InnerException != null)
            {
                StringBuilder message = new StringBuilder();
                message.AppendLine(GetExceptionTypeStack(e.InnerException));
                message.AppendLine(e.GetType().ToString());
                return (message.ToString());
            }
            else return e.GetType().ToString();
        }

        private static string GetExceptionMessageStack(Exception e)
        {
            if (e.InnerException != null)
            {
                StringBuilder message = new StringBuilder();
                message.AppendLine(GetExceptionMessageStack(e.InnerException));
                message.AppendLine(e.Message);
                return (message.ToString());
            }
            else return e.Message;
        }

        private static string GetExceptionCallStack(Exception e)
        {
            if (e.InnerException != null)
            {
                StringBuilder message = new StringBuilder();
                string innerStack = GetExceptionCallStack(e.InnerException);
                if (!string.IsNullOrEmpty(innerStack))
                {
                    message.AppendLine(FileUtils.HEADER_STACK_TRACE);
                    message.AppendLine(GetExceptionCallStack(e.InnerException));
                }

                if (e.StackTrace != null)
                {
                    message.AppendLine("--- Next Call Stack:");
                    message.AppendLine(e.StackTrace);
                }
                return (message.ToString());
            }
            else return e.StackTrace;
        }





    }
}
