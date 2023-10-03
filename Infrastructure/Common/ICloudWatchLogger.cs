namespace Infrastructure.Common;

public interface ICloudWatchLogger
{
    void SetLogGroup(string logGroup);
    void SetLogStream(string logStream);
    Task InitLoggerAsync(string logGroupPrefix);
    Task LogMessageAsync(string message);
    Task LogMessageAsync(string methodName, long milliseconds);
    Task LogMessageAsync(Exception exception);
}

