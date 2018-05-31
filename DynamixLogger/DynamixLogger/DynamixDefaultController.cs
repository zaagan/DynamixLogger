using System;
using DynamixLogger;
using DynamixLogger.Info;
using DynamixLogger.LogStrategy.File;
using DynamixLogger.LogStrategy;
using DynamixLogger.Utilities;
using System.Diagnostics;

namespace DynamixLogger
{
    public class DynamixDefaultController
    {

        public static bool EnableDevelopmentLog { get; set; } = true;

        /// <summary>
        /// This represents your Logger Name 
        /// </summary>
        public const string LoggerName = "Dynamix";

        public const string PostFileName = "-{0:yyyy-MM-dd}.log";

        public const string Execution_LogFolderName = LoggerName + "ExLogs";

        public const string ExecutionLogFileFormat = LoggerName + PostFileName;


        protected FileLogInfo fileLogInfo = null;

        protected ILogStrategy<FileLogInfo> logInfo = null;



        public DynamixDefaultController()
        {
            if (EnableDevelopmentLog)
            {
                fileLogInfo = DefaultFileLogInfo();
                logInfo = new FileLogger<FileLogInfo>();
            }
        }
        
        protected void LogMessage(Exception ex)
        {
            if (EnableDevelopmentLog)
                try { LogEngine.LogMessage(logInfo, fileLogInfo, ex); }
                catch
                {
                    // YOU CAN LOG TO THE EVENT VIEWER HERE
                }
        }

        protected void LogMessage(string message)
        {
            if (EnableDevelopmentLog)
                try { LogEngine.LogMessage(logInfo, fileLogInfo, message); }
                catch
                {
                    // YOU CAN LOG TO THE EVENT VIEWER HERE
                }
        }


        public Exception ShortException<T>(string message, T at) where T : new()
        {
            if (at != null)
                return new Exception($"{message.Trim()} at {at}");
            else
                return new Exception($"{message.Trim()}");
        }

        public Exception ShortException<T>(Exception message, T at) where T : new()
        {
            if (at != null)
                return new Exception($"{message.ToString().Trim()} at {at}");
            else
                return new Exception($"{message.ToString().Trim()}");

        }


        public string ShortMessage<T>(string message, T at) where T : new()
        {
            if (at != null)
                return $"{message.Trim()} at {at}";
            else
                return $"{message.Trim()}";

        }



        /// <summary>
        /// Instantiate your Log Info Type Here
        /// You can even create your own File Log Info class as per your need
        /// </summary>
        /// <returns></returns>
        public static FileLogInfo DefaultFileLogInfo()
        {
            FileLogInfo fileLogInfo = new FileLogInfo();
            fileLogInfo.FilePath = FilePaths.ChooseADrive(FileUtils.SpaceLimit, true).Name;
            fileLogInfo.DedicatedFolder = true;
            fileLogInfo.FolderName = Execution_LogFolderName;
            fileLogInfo.FileName = GenerateLogFileName();
            fileLogInfo.Presentation = Presentation.FULL_DETAIL;
            return fileLogInfo;
        }



        /// <summary>
        /// Generate Execution Log File Name
        /// </summary>
        /// <returns></returns>
        public static string GenerateLogFileName()
        {
            string fileName = string.Format(ExecutionLogFileFormat, DateTime.Now);
            return fileName;
        }




    }
}
