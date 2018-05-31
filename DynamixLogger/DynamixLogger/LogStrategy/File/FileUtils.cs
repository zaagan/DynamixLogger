using System;
using System.IO;
using System.Reflection;
using DynamixLogger.Utilities;
using DynamixLogger.Info;

namespace DynamixLogger.LogStrategy.File
{
    public class FileUtils
    {
        public const long SpaceLimit = 5368709120; // [ 5 GB ]

        public const string LogFilderMinSpace = "";
        public const string Default_File_PreHeader = "dynamix";
        public const string Default_File_Ext = ".txt";
        public const string Default_LineBreaker = "---------------------";
        public const string Default_File_DateAppendor = "yyyyMMdd-HHmmss";
        public const bool Default_Required_Dedicated_Folder = false;
        public const string Default_Log_FolderName = "Log";
        public const bool Default_Enable_Date = true;
        public static string Default_Log_Name = ExtractCallerName(); /* "dynamix.txt";*/
        public const string Default_Date_Format = DateFormat.G;
        public const string Default_Log_Message = "The quick brown fox jumps over the lazy dog";

        public const string HEADER_SOURCE = "Source: ";
        public const string HEADER_EVENT_ID = "Event ID: ";
        public const string HEADER_EXCEPTION_CLASS = "Exception Class: ";
        public const string HEADER_EXCEPTION_MSG = "Exception Message: ";
        public const string HEADER_STACK_TRACE = "Stack Traces: ";
        public const string HEADER_APP_UP_TIME = "Application Up Time: ";
        public const string HEADER_SEVERITY = "Severity: ";
        public const string HEADER_Message = "Message: ";
        public const string HEADER_Message_General = "General: ";
        public const string HEADER_Error_Code = "Error Code: ";


        /// <summary>
        /// CREATE LOG FILE NAME WITH DEFAULT EXTENSION BASED ON THE CALLING ASSEMBLY
        /// </summary>
        /// <returns></returns>
        public static string ExtractCallerName()
        {
            string name = FileUtils.Default_File_PreHeader + Default_File_Ext;
            try
            {
                string assemblyName = Assembly.GetCallingAssembly().FullName;
                string[] info = assemblyName.Split(',');
                if (info != null && info.Length > 0) name = info[0] + Default_File_Ext;
            }
            catch { }

            return name;
        }


        public static void ValidateLogFileDefaults(FileLogInfo fileLogInfo)
        {
            fileLogInfo.FileName.CheckEmpty(ErrorCode.CDX_NO_VALUE, Messages.FILE_NAME_MISSING);

            fileLogInfo.FilePath.CheckEmpty(ErrorCode.CDX_NO_VALUE, Messages.FILE_PATH_MISSING);

            if (fileLogInfo.LogType == LogType.Message) fileLogInfo.LogMessage.CheckEmpty(ErrorCode.CDX_NO_VALUE, Messages.FILE_LOG_MESSAGE_MISSING);
            else
            {
                if (fileLogInfo.Exception == null) throw ErrorGenerator.Generate(ErrorCode.CDX_NO_VALUE, Messages.FILE_LOG_EXCEPTION_MISSING);
            }
        }




        public static string CheckOrCreateLogDirectory(FileLogInfo fileLogInfo)
        {
            if (fileLogInfo.DedicatedFolder)
            {
                string fullPath = Path.Combine(fileLogInfo.FilePath, fileLogInfo.FolderName);
                if (!Directory.Exists(fullPath))
                    Directory.CreateDirectory(fullPath);

                return fullPath;
            }
            else
                return fileLogInfo.FilePath;
        }



        /// <summary>
        /// Generate A file name based on the provided information
        /// </summary>
        /// <param name="fileLogInfo"></param>
        /// <returns></returns>
        public static string GenerateFileName(FileLogInfo fileLogInfo)
        {
            string extension = Path.GetExtension(fileLogInfo.FileName);

            if (extension.Trim() == string.Empty) extension = FileUtils.Default_File_Ext;

            string fileName = Path.GetFileNameWithoutExtension(fileLogInfo.FileName);

            if (fileLogInfo.InsertionType == InsertionType.NewFile)
                fileName += "-" + DateTime.Now.Date.ToString(Default_File_DateAppendor);

            fileName += extension;

            return fileName;
        }




    }

}
