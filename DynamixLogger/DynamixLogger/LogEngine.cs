using DynamixLogger.LogStrategy;
using System;
using DynamixLogger.Utilities;
using DynamixLogger.Info;
using DynamixLogger.LogStrategy.File;

namespace DynamixLogger
{
    /// <summary>
    /// Examples on using DynamixLogger for logging
    /// </summary>
    public class LogEngine
    {

   

        /// <summary>
        /// LOG EXCEPTION TO FILE
        /// </summary>
        /// <param name="logInfo"></param>
        /// <param name="fileLogInfo"></param>
        /// <param name="ex"></param>
        public static ILogMessage LogMessage<T>(ILogStrategy<T> logInfo, T fileLogInfo, Exception ex, LogLevel logLevel = LogLevel.ERROR) where T : FileLogInfo
        {
            fileLogInfo.LogType = LogType.Exception;
            fileLogInfo.LogLevel = logLevel;
            fileLogInfo.Exception = ex;
            return LogWriter<T>.Write(logInfo, fileLogInfo);
        }


        /// <summary>
        /// LOG MESSAGE TO FILE 
        /// </summary>
        /// <param name="logInfo"></param>
        /// <param name="fileLogInfo"></param>
        /// <param name="message"></param>
        public static ILogMessage LogMessage<T>(ILogStrategy<T> logInfo, T fileLogInfo, string message, LogLevel logLevel = LogLevel.INFO) where T : FileLogInfo
        {
            fileLogInfo.LogType = LogType.Message;
            fileLogInfo.LogLevel = logLevel;
            fileLogInfo.LogMessage = message;
            return LogWriter<T>.Write(logInfo, fileLogInfo);
        }



        /// <summary>
        /// Log Diagnostic Message
        /// </summary>
        /// <param name="baseLogInfo"></param>
        public void LogMessage<T>(T baseLogInfo) where T : BaseLogInfo
        {
            ILogStrategy<T> logStrategy = new DiagnosticsLogger<T>();
            ILogMessage messageCode = LogWriter<T>.Write(logStrategy, baseLogInfo);
        }


    }
}
