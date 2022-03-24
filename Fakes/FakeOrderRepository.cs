public class FakeOrderRepository : IOrderRepository
{
    private List<Order> _orders = new();
    public Task<Order> AddOrder(Order order)
    {
        _orders.Add(order);
        return Task.FromResult(order);
    }
}