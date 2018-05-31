namespace DynamixLogger.Utilities
{
    internal static class StringValidator
    {

        public static void CheckEmpty(this string data, string errorCode, string message)
        {
            if (string.IsNullOrEmpty(data)) throw ErrorGenerator.Generate(errorCode, message);
        }
    }

}
