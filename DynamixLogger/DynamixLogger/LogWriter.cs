namespace DynamixLogger
{
    /// <summary>
    /// LOG MIDDLEWARE: WRITE MESSAGE TO THE USER DEFINED LOG HANDLER
    /// </summary>
    /// <typeparam name="T">LogInfo</typeparam>
    public static class LogWriter<T> where T : IBaseLogInfo
    {

        /// <summary>
        /// WRITE LOG TO THE DEFINED LOG HANDLER
        /// </summary>
        /// <param name="logStrategy">Strategy to choose</param>
        /// <param name="messageInfo">Message to be written</param>
        /// <returns></returns>
        public static ILogMessage Write(ILogStrategy<T> logStrategy, T messageInfo)
        {
            return logStrategy.Write(messageInfo);
        }
    }



}
