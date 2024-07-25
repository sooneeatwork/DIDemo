using DIDemo.Logging;
using DIDemo.Configuration;

namespace DIDemo.Services
{
    public class EmailServiceWithoutDI
    {
        private readonly ConsoleLogger _logger;
        private readonly EmailConfiguration _config;

        public EmailServiceWithoutDI()
        {
            _logger = new ConsoleLogger(new LoggerConfiguration());
            _config = new EmailConfiguration();
        }

        public void SendEmail(string to, string subject, string body)
        {
            _logger.Log($"Sending email to {to} with subject: {subject}", LogLevel.Info);
            // Email sending logic here using _config
            _logger.Log($"Email sent successfully to {to}", LogLevel.Info);
        }
    }
}