using DIDemo.Logging;

namespace DIDemo.Logging
{
    public interface ILogger
    {
        void Log(string message, LogLevel level);
    }
}