using System;
using System.Configuration;
using System.Data.SqlClient;
using DynamixLogger.Utilities;
using DynamixLogger.Info;

namespace DynamixLogger.LogStrategy.MsSQL
{
    public class SQLUtil
    {
        public static string GenerateConnectionString(bool integratedSecurity, string dataSource, string databaseName, string userName, string pwd)
        {

            if (dataSource == null || dataSource.Trim() == string.Empty)
                return string.Empty;

            if (databaseName == null || databaseName.Trim() == string.Empty)
                return string.Empty;

            if (userName == null || userName.Trim() == string.Empty)
                return string.Empty;

            if (pwd == null || pwd.Trim() == string.Empty)
                return string.Empty;

            SqlConnectionStringBuilder connbuilder = new SqlConnectionStringBuilder();

            connbuilder.DataSource = dataSource.Trim();
            connbuilder.IntegratedSecurity = integratedSecurity;

            if (!integratedSecurity)
            {
                connbuilder.UserID = userName.Trim();
                connbuilder.Password = pwd.Trim();
            }

            connbuilder.InitialCatalog = databaseName.Trim();

            return connbuilder.ConnectionString;

        }



        public static string GetConnectionString(SqlLogInfo sqlLogInfo)
        {
            string connectionString = string.Empty;
            if (sqlLogInfo.FetchFromConfig)
            {
                sqlLogInfo.ConnectionStringKey.Trim().CheckEmpty(ErrorCode.CDX_NO_VALUE, Messages.CONNECTION_STRING_KEY_MISSING);

                try
                { connectionString = ConfigurationManager.AppSettings[sqlLogInfo.ConnectionStringKey].ToString(); }
                catch (Exception ex)
                { throw ErrorGenerator.Generate(ErrorCode.CDX_NO_VALUE, ex.Message); }

                if (connectionString == null)
                    throw ErrorGenerator.Generate(ErrorCode.CDX_NO_VALUE, Messages.CONNECTION_STRING_READ_ERROR);
            }
            else
            {
                // GENERATE CONNECTIONSTRING
                connectionString = sqlLogInfo.GetConnectionString();
            }
            return connectionString;
        }


        public static void ValidateSQLAuthentication(SqlLogInfo sqlLogInfo)
        {
            sqlLogInfo.ServerName.Trim().CheckEmpty(ErrorCode.CDX_NO_VALUE, Messages.SQL_SERVER_NAME_MISSING);
          
            sqlLogInfo.UserName.Trim().CheckEmpty(ErrorCode.CDX_NO_VALUE, Messages.SQL_USER_NAME_MISSING);

            sqlLogInfo.Password.Trim().CheckEmpty(ErrorCode.CDX_NO_VALUE, Messages.SQL_PWD_MISSING);
        }



        public static Type GetConversionType()
        {

            return typeof(int);
        }
    }
}
