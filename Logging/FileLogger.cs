using DIDemo.Configuration;

namespace DIDemo.Logging
{
    public class FileLogger : ILogger
    {
        private readonly LoggerConfiguration _config;

        public FileLogger(LoggerConfiguration config)
        {
            _config = config;
        }

        public void Log(string message, LogLevel level)
        {
            if (level >= _config.MinimumLogLevel)
            {
                Console.WriteLine($"Pretend I am file logger [{level}] {message} ");
            }
        }
    }
}