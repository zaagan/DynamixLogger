using DynamixLogger.Utilities;

namespace DynamixLogger
{
    public interface IBaseLogInfo
    {
        LogLevel LogLevel { get; set; }
        string LogMessage { get; set; }
    }
}
