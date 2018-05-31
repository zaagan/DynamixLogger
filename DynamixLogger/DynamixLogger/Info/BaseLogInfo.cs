using DynamixLogger.Utilities;


namespace DynamixLogger.Info
{
    public class BaseLogInfo : IBaseLogInfo
    {
        public LogLevel LogLevel { get; set; }
        public string LogMessage { get; set; }
    }
}
