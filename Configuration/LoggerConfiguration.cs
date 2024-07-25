using DIDemo.Logging;

namespace DIDemo.Configuration
{
    public class LoggerConfiguration
    {
        public string FilePath { get; set; } = "log.txt";
        public string ConnectionString { get; set; } = "DefaultConnection";
        public LogLevel MinimumLogLevel { get; set; } = LogLevel.Info;
    }
}