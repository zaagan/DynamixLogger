namespace DynamixLogger.Utilities
{
    public enum LogLevel { INFO = 1, WARNING = 2, ERROR = 3, EXCEPTION = 4, DEBUG = 0 }

    public enum LogType { Message, Exception }

    public static class StatusType
    {
        public const int SUCCESS = 1;
        public const int EXCEPTION = -2;
        public const int ERROR = -1;
    }

    /// <summary>
    /// CHOOSE HOW THE LOG SHOULD BE PRESENTED
    /// </summary>
    public enum Presentation { LOG__ONLY = 1, LOG_WITH_SEVERITY = 2, FULL_DETAIL = 3, CUSTOM = 0 }

    public enum InsertionType { Append, NewFile }

    public enum SQLCallType { StoredProcedure = 0, Query = 1 }


}
