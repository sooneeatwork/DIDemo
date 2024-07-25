using DIDemo.Logging;

namespace DIDemo.Services
{
    public class UserServiceWithoutDI
    {
        private readonly FileLogger _logger;
        private readonly EmailServiceWithoutDI _emailService;

        public UserServiceWithoutDI()
        {
            _logger = new FileLogger(new Configuration.LoggerConfiguration());
            _emailService = new EmailServiceWithoutDI();
        }

        public void RegisterUser(string username)
        {
            _logger.Log($"Attempting to register user: {username}", LogLevel.Debug);
            // Registration logic here
            _logger.Log($"User registered successfully: {username}", LogLevel.Info);

            _emailService.SendEmail(username, "Welcome!", "Welcome to our service!");
        }
    }
}