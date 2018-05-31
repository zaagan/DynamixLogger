using System.Collections.Generic;

namespace DynamixLogger.LogStrategy.MsSQL
{
    public class StoredProcedureInfo
    {
        public List<KeyValuePair<string, object>> LogParams { get; set; }

        public string StoredProcedureName { get; set; }

        public string OutputParameterName
        {
            get { return outputParameterName; }
            set { outputParameterName = value; }
        }
        private string outputParameterName = string.Empty;


        public string ExecutionType { get; set; }

    }
}
