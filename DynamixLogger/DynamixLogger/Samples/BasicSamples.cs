using DynamixLogger.Info;
using DynamixLogger.LogStrategy.File;
using DynamixLogger.Utilities;
using System;
using DynamixLogger.LogStrategy;


namespace DynamixLogger.Samples
{
    /// <summary>
    /// Sample code on how to implement the logger
    /// </summary>
    public class BasicSamples
    {
        ILogStrategy<FileLogInfo> logInfo = null;
        FileLogInfo fileLogInfo = null;

        public BasicSamples()
        {
            logInfo = new FileLogger<FileLogInfo>();
            fileLogInfo = new FileLogInfo();

            fileLogInfo.FilePath = FilePaths.ChooseADrive(FileUtils.SpaceLimit, true).Name;
            fileLogInfo.DedicatedFolder = true;
            fileLogInfo.FolderName = "YOUR-CUSTOM-FOLDER-NAME"; // <---- Optional
            fileLogInfo.FileName = "YOUR-CUSTOM-FILE-NAME.log";  // <---- Optional
            fileLogInfo.Presentation = Presentation.FULL_DETAIL;
        }

        public void LogMessage(string someMessage) { LogEngine.LogMessage(logInfo, fileLogInfo, someMessage); }

        public void LogException(Exception ex) { LogEngine.LogMessage(logInfo, fileLogInfo, ex); }


        public static void StandardLogging()
        {

            FileLogInfo fileLogInfo = new FileLogInfo();
            fileLogInfo.FilePath = FilePaths.ChooseADrive(FileUtils.SpaceLimit, true).Name;
            fileLogInfo.DedicatedFolder = true; // <---- Optional
            fileLogInfo.FolderName = "Your-Folder-Name"; // <---- Optional
            fileLogInfo.FileName = "Your-File-Name"; // <---- Optional
            fileLogInfo.Presentation = Presentation.FULL_DETAIL;

            ILogStrategy<FileLogInfo> logInfo = new FileLogger<FileLogInfo>();

            LogEngine.LogMessage(logInfo, fileLogInfo, "Your-Message");
            // OR
            LogEngine.LogMessage(logInfo, fileLogInfo, new Exception("Your-Exception"));
        }
    }
}
