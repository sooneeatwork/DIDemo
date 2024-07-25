using DIDemo.Configuration;

namespace DIDemo.Logging
{
    public class DatabaseLogger : ILogger
    {
        private readonly LoggerConfiguration _config;

        public DatabaseLogger(LoggerConfiguration config)
        {
            _config = config;
        }

        public void Log(string message, LogLevel level)
        {
            if (level >= _config.MinimumLogLevel)
            {
                Console.WriteLine($"[DB] [{level}] {message} (Connection: {_config.ConnectionString})");
                // In a real scenario, this would write to a database
            }
        }
    }
}