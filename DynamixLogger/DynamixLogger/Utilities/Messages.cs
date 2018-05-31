namespace DynamixLogger.Utilities
{
    /// <summary>
    /// Contains Static Messages
    /// </summary>
    internal class Messages
    {
        public const string NULL_VALUE_EXCEPTION = "No information found";

        public const string NULL_LOG_INFO = "The LogInfo was supplied with a null value";
        public const string NULL_SP_INFO = "The StoredProcedure info was supplied with a null value";
        public const string EMPTY_QUERY = "The Query info was not supplied";

        #region ---- TYPE CASE ERRORS ----
        public const string CAST_BASELOGINFO_EXPECTED = "Expecting a type of BaseLogInfo";
        public const string CAST_SQLLOGINFO_EXPECTED = "Expecting a type of SqlLogInfo";
        public const string CAST_FILELOGINFO_EXPECTED = "Expecting a type of FileLogInfo";
        #endregion

        public const string VALUE_MISSING = "A value was not supplied";
        public const string LOG_SUCCESSFULL = "Message logging successfull";

        public const string CONNECTION_STRING_KEY_MISSING = "Could not find a connection string";
        public const string CONNECTION_STRING_READ_ERROR = "Error while reading the connection string";

        public const string FILE_NAME_MISSING = "File Name is missing";
        public const string FILE_PATH_MISSING = "File Path is missing";
        public const string FILE_LOG_MESSAGE_MISSING = "Log Message is missing";
        public const string FILE_LOG_EXCEPTION_MISSING = "Could not read the exception message";

        #region ---- MISSING VALUES ----
        public const string SQL_SERVER_NAME_MISSING = "Server Name is missing";
        public const string SQL_DATABASE_NAME_MISSING = "Database Name is missing";
        public const string SQL_USER_NAME_MISSING = "UserName is missing";
        public const string SQL_PWD_MISSING = "Password is missing";
        public const string SQL_SP_NAME_MISSING = "A Stored Procedure name is missing";
        #endregion
        //public const string SQL_Query_Missing = "Execution Query should be defined";
        //public const string SQL_Authentication_Failed = "Authentication Failed";

    }
}
