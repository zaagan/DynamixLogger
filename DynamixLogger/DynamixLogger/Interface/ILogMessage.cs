namespace DynamixLogger
{
    public interface ILogMessage
    {
        int Status { get; set; }

        string Message { get; set; }
    }
}
