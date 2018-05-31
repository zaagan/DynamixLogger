namespace DynamixLogger
{
    public interface ILogStrategy<T>
    {
        ILogMessage Write(T logInfo);
    }
}
