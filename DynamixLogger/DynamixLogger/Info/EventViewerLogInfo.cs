using DynamixLogger.Utilities;

namespace DynamixLogger.Info
{
    public class EventViewerLogInfo : IBaseLogInfo
    {
        public LogLevel LogLevel { get; set; }

        public string LogMessage { get; set; }

    }
}
