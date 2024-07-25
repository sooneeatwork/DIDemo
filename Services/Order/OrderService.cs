using DIDemo.Logging;

namespace DIDemo.Services
{
    public class OrderService : IOrderService
    {
        private readonly ILogger _logger;
        private readonly IEmailService _emailService;

        public OrderService(ILogger logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
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