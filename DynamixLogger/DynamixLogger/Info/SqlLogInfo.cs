using DynamixLogger.LogStrategy.MsSQL;
using DynamixLogger.Utilities;

namespace DynamixLogger.Info
{
    public class SqlLogInfo : IBaseLogInfo
    {
        public LogLevel LogLevel { get; set; }

        public string LogMessage { get; set; }

        public SQLCallType CallType { get; set; }

        /// <summary>
        /// Use connection string from the config file
        /// </summary>
        public bool FetchFromConfig { get { return fetchConnectionStringFromConfigFile; } set { fetchConnectionStringFromConfigFile = value; } }

        private bool fetchConnectionStringFromConfigFile = false;

        /// <summary>
        /// The Connection String key from the config file
        /// </summary>
        public string ConnectionStringKey { get { return connectionStringKey; } set { connectionStringKey = value; } }

        private string connectionStringKey = string.Empty;


        /// <summary>
        /// Authenticate using windows authentication
        /// </summary>
        public bool WindowsAuthentication { get { return windowsAuthentication; } set { windowsAuthentication = value; } }

        private bool windowsAuthentication = false;


        /// <summary>
        /// Write custom query
        /// </summary>
        public bool CustomQuery { get { return customQuery; } set { customQuery = value; } }

        private bool customQuery = false;


        /// <summary>
        /// Query to be implemented if custom query is enabled
        /// </summary>
        public string Query { get { return query; } set { query = value; } }

        private string query = string.Empty;


        public string ServerName { get; set; }
        public string Database { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


        public StoredProcedureInfo StoredProcedureInfo { get { return spInfo; } set { spInfo = value; } }

        private StoredProcedureInfo spInfo = null;


        public string GetConnectionString()
        {
            return SQLUtil.GenerateConnectionString(WindowsAuthentication, ServerName, Database, UserName, Password);
        }




    }
}
