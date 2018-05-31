using DynamixLogger.LogStrategy.File;
using System;
using System.IO;
using DynamixLogger.Utilities;
using DynamixLogger.Info;

namespace DynamixLogger.LogStrategy
{

    /// <summary>
    /// LOG ERROR MESSAGE TO FILE
    /// </summary>
    public class FileLogger<T> : ILogStrategy<T> where T : FileLogInfo
    {
        string source = string.Empty;
        string eventID = string.Empty;

        public FileLogger() { }

        public FileLogger(string source, string eventID)
        {
            this.source = source.Trim();
            this.eventID = eventID.Trim();
        }

        public ILogMessage Write(T logInfo)
        {
            try
            {
                if (logInfo == null)
                    throw ErrorGenerator.Generate(ErrorCode.CDX_NO_VALUE, Messages.NULL_LOG_INFO);

                if (typeof(T) != typeof(FileLogInfo))
                    throw ErrorGenerator.Generate(ErrorCode.CDX_FILE_CAST_FAIL);

                FileLogInfo fileLogInfo = logInfo as FileLogInfo;

                FileUtils.ValidateLogFileDefaults(fileLogInfo);

                if (fileLogInfo.EnableDate && string.IsNullOrEmpty(fileLogInfo.LogDateFormat))
                    fileLogInfo.LogDateFormat = FileUtils.Default_Date_Format;

                if (fileLogInfo.DedicatedFolder && string.IsNullOrEmpty(fileLogInfo.FolderName))
                    fileLogInfo.FolderName = FileUtils.Default_Log_FolderName;

                // [ WRITE LOG TO FILE ]
                WriteLog(fileLogInfo);

                fileLogInfo.LogMessage = string.Empty;
                return new LogMessageCode() { Status = StatusType.SUCCESS, Message = Messages.LOG_SUCCESSFULL };
            }
            catch (Exception ex) { return new LogMessageCode() { Status = StatusType.EXCEPTION, Message = ex.Message }; }
        }


        private void WriteLog(FileLogInfo fileLogInfo)
        {
            switch (fileLogInfo.LogType)
            {
                case LogType.Exception: LogException(fileLogInfo); break;

                default: LogMessage(fileLogInfo); break;
            }
        }


        private void LogException(FileLogInfo fileLogInfo)
        {
            string logMessage = string.Empty;

            switch (fileLogInfo.Presentation)
            {
                case Presentation.FULL_DETAIL: logMessage = MessageLogUtility.GenerateFullLogDetail_EX(fileLogInfo, source, eventID); break;

                case Presentation.LOG_WITH_SEVERITY: logMessage = MessageLogUtility.GenerateLogWithSeverity(fileLogInfo, true); break;

                case Presentation.LOG__ONLY: default: logMessage = MessageLogUtility.GenerateLogOnly(fileLogInfo, isException: true); break;

                case Presentation.CUSTOM: break;
            }

            string pathTillDrive = FileUtils.CheckOrCreateLogDirectory(fileLogInfo);
            WriteToFile(fileLogInfo, logMessage, pathTillDrive, appendLine: true);

        }

        private void LogMessage(FileLogInfo fileLogInfo)
        {
            string logMessage = string.Empty;

            // [ HOW THE MESSAGE SHOULD BE PRESENTED ]
            switch (fileLogInfo.Presentation)
            {
                case Presentation.FULL_DETAIL: logMessage = MessageLogUtility.GenerateFullLogDetail(fileLogInfo, source, eventID); break;

                case Presentation.LOG_WITH_SEVERITY: logMessage = MessageLogUtility.GenerateLogWithSeverity(fileLogInfo, false); break;

                case Presentation.LOG__ONLY: logMessage = MessageLogUtility.GenerateLogOnly(fileLogInfo, isException: false); break;

                case Presentation.CUSTOM: logMessage = fileLogInfo.LogMessage.Trim(); break;
            }

            string pathTillDrive = FileUtils.CheckOrCreateLogDirectory(fileLogInfo);
            WriteToFile(fileLogInfo, logMessage, pathTillDrive, appendLine: true);

            //// [ HOW THE MESSAGE SHOULD BE INSERTED ]   ------- WORK OUT HERE >> 
            //switch (fileLogInfo.InsertionType)
            //{
            //    case InsertionType.Append:
            //        WriteToFile(fileLogInfo, logMessage, pathTillDrive, appendLine: true);
            //        break;

            //    case InsertionType.NewFile:
            //        WriteToFile(fileLogInfo, logMessage, pathTillDrive, appendLine: true);
            //        break;
            //}
        }


        private void WriteToFile(FileLogInfo fileLogInfo, string message, string path, bool appendLine)
        {
            if (string.IsNullOrEmpty(fileLogInfo.FileName))
                fileLogInfo.FileName = FileUtils.Default_Log_Name;

            string fileName = FileUtils.GenerateFileName(fileLogInfo);

            string fullPath = Path.Combine(path, fileName);
            using (StreamWriter writer = new StreamWriter(fullPath, appendLine))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }


    }

}
