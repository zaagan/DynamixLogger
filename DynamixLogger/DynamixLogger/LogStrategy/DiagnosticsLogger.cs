using System;
using DynamixLogger.Utilities;
using DynamixLogger.Info;

namespace DynamixLogger.LogStrategy
{
    /// <summary>
    /// LOG ERROR MESSAGE TO SYSTEM TRACE
    /// </summary>
    public class DiagnosticsLogger<T> : ILogStrategy<T> where T : BaseLogInfo
    {

        /// <summary>
        /// WRITE LOG TO THE SYSTEM TRACE 
        /// </summary>
        /// <param name="logInfo"></param>
        /// <returns></returns>
        public ILogMessage Write(T logInfo)
        {
            try
            {
                if (logInfo == null)
                    throw ErrorGenerator.Generate(ErrorCode.CDX_NO_VALUE, Messages.NULL_LOG_INFO);

                if (typeof(T) != typeof(BaseLogInfo))
                    throw ErrorGenerator.Generate(ErrorCode.CDX_SQL_CAST_FAIL);

                BaseLogInfo baseLogInfo = logInfo as BaseLogInfo;

                System.Diagnostics.Trace.WriteLine(baseLogInfo.LogLevel.ToString() + ": " + baseLogInfo.LogMessage);

                return new LogMessageCode() { Status = StatusType.SUCCESS, Message = Messages.LOG_SUCCESSFULL };

            }
            catch (Exception ex)
            { return new LogMessageCode() { Status = StatusType.EXCEPTION, Message = ex.Message }; }

        }

    }


}
