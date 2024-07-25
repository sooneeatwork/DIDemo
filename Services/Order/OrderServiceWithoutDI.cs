using DIDemo.Logging;

namespace DIDemo.Services
{
    public class OrderServiceWithoutDI
    {
        private readonly FileLogger _logger;
        private readonly EmailServiceWithoutDI _emailService;

        public OrderServiceWithoutDI()
        {
            _logger = new FileLogger(new Configuration.LoggerConfiguration { MinimumLogLevel = LogLevel.Info });
            _emailService = new EmailServiceWithoutDI();
        }

        public void PlaceOrder(string userId, string productId)
        {
            _logger.Log($"Placing order for user {userId}, product {productId}", LogLevel.Info);
            // Order placement logic here
            _logger.Log($"Order placed successfully for user {userId}", LogLevel.Info);

            _emailService.SendEmail(userId, "Order Confirmation", $"Your order for product {productId} has been placed.");
        }
    }
}