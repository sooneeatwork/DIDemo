namespace DIDemo.Services
{
    public interface IOrderService
    {
        void PlaceOrder(string userId, string productId);
    }
}