using System;
using DynamixLogger.Utilities;
using DynamixLogger.Info;

namespace DynamixLogger.LogStrategy
{
    /// <summary>
    /// LOG ERROR MESSAGES TO SQL DATABASE
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SqlDbLogger<T> : ILogStrategy<T> where T : SqlLogInfo
    {

        /// <summary>
        /// WRITE LOG TO DATABASE
        /// </summary>
        /// <param name="logInfo">Database and message definition</param>
        /// <returns></returns>
        public ILogMessage Write(T logInfo)
        {
            try
            {
                if (logInfo == null)
                    throw ErrorGenerator.Generate(ErrorCode.CDX_NO_VALUE, Messages.NULL_LOG_INFO);

                if (typeof(T) != typeof(SqlLogInfo))
                    throw ErrorGenerator.Generate(ErrorCode.CDX_SQL_CAST_FAIL);

                SqlLogInfo sqlLogInfo = logInfo as SqlLogInfo;

                sqlLogInfo.Database.Trim().CheckEmpty(ErrorCode.CDX_NO_VALUE, Messages.SQL_DATABASE_NAME_MISSING);

                if (!sqlLogInfo.WindowsAuthentication)
                    MsSQL.SQLUtil.ValidateSQLAuthentication(sqlLogInfo);

                // [ CONFIGURE CONNECTION STRING ]
                string connectionString = MsSQL.SQLUtil.GetConnectionString(sqlLogInfo);


                if (sqlLogInfo.CallType == SQLCallType.Query) sqlLogInfo.Query.CheckEmpty(ErrorCode.CDX_NO_VALUE, Messages.EMPTY_QUERY);
                else
                {
                    if (sqlLogInfo.StoredProcedureInfo == null) throw ErrorGenerator.Generate(ErrorCode.CDX_NO_VALUE, Messages.NULL_SP_INFO);

                    sqlLogInfo.StoredProcedureInfo.StoredProcedureName.CheckEmpty(ErrorCode.CDX_NO_VALUE, Messages.SQL_SP_NAME_MISSING);

                    if (sqlLogInfo.StoredProcedureInfo.LogParams == null || sqlLogInfo.StoredProcedureInfo.LogParams.Count <= 0)
                    {
                        MsSQL.MsSQLHandler handler = new MsSQL.MsSQLHandler(connectionString);


                    }

                }


                // WRITE LOG TO SQL

                return new LogMessageCode() { Status = StatusType.SUCCESS, Message = Messages.LOG_SUCCESSFULL };
            }
            catch (Exception ex)
            {
                return new LogMessageCode() { Status = StatusType.EXCEPTION, Message = ex.Message };
            }
        }




    }
}
