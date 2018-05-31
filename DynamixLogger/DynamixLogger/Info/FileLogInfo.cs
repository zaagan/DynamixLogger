using System;
using DynamixLogger.Utilities;
using DynamixLogger.LogStrategy.File;

namespace DynamixLogger.Info
{
    public class FileLogInfo : IBaseLogInfo
    {
        /// <summary>
        /// LOG FILE NAME
        /// </summary>
        public string FileName { get; set; } = FileUtils.Default_Log_Name;


        /// <summary>
        /// PATH TILL THE DIRECTORY WHERE THE LOG FILE SHOULD BE STORED
        /// </summary>
        public string FilePath { get; set; } = FilePaths.ApplicationFolder;

        /// <summary>
        /// LOG SEVERITY
        /// </summary>
        public LogLevel LogLevel { get; set; } = LogLevel.INFO;


        /// <summary>
        /// REQUIRE A DEDICATED FOLDER FOR THE LOG
        /// </summary>
        public bool DedicatedFolder { get; set; } = FileUtils.Default_Required_Dedicated_Folder;


        /// <summary>
        /// LOG DIRECTORY NAME
        /// </summary>
        public string FolderName { get; set; } = FileUtils.Default_Log_FolderName;


        /// <summary>
        /// ACTUAL LOG MESSAGE
        /// </summary>
        public string LogMessage { get; set; } = string.Empty;


        /// <summary>
        /// ENABLE/ DISABLE DATE
        /// </summary>
        public bool EnableDate { get; set; } = FileUtils.Default_Enable_Date;


        /// <summary>
        /// THE LOG DATE FORMAT
        /// </summary>
        public string LogDateFormat { get; set; } = DateFormat.G;// FileUtils.Default_Date_Format;



        /// <summary>
        /// CHOOSE HOW THE LOG SHOULD BE INSERTED
        /// </summary>
        public InsertionType InsertionType { get; set; } = InsertionType.Append;


        /// <summary>
        /// CHOOSE HOW THE LOG SHOULD BE PRESENTED
        /// </summary>
        public Presentation Presentation { get; set; } = Presentation.FULL_DETAIL;


        /// <summary>
        /// ERROR CODE FOR SELF MOTIVE
        /// </summary>
        public string ErrorCode { get; set; } = string.Empty;


        /// <summary>
        /// Log Type: Message or Exception
        /// </summary>
        public LogType LogType { get; set; } = LogType.Message;


        /// <summary>
        /// Exception
        /// </summary>
        public Exception Exception { get; set; } = null;


    }

}
