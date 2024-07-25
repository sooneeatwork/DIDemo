using DIDemo.Logging;
using DIDemo.Configuration;

namespace DIDemo.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger _logger;
        private readonly EmailConfiguration _config;

        public EmailService(ILogger logger, EmailConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public void SendEmail(string to, string subject, string body)
        {
            _logger.Log($"Sending email to {to} with subject: {subject}", LogLevel.Info);
            // Email sending logic here using _config
            _logger.Log($"Email sent successfully to {to}", LogLevel.Info);
        }
    }
}