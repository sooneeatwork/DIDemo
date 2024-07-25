using DIDemo.Logging;

namespace DIDemo.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger _logger;
        private readonly IEmailService _emailService;

        public UserService(ILogger logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
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