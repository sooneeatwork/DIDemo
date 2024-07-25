using DIDemo.Configuration;

namespace DIDemo.Logging
{
    public class ConsoleLogger : ILogger
    {
        private readonly LoggerConfiguration _config;

        public ConsoleLogger(LoggerConfiguration config)
        {
            _config = config;
        }

        public void Log(string message, LogLevel level)
        {
            if (level >= _config.MinimumLogLevel)
            {
                Console.WriteLine($"[{level}] {message}");
            }
        }
    }
}