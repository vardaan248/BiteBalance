namespace OrderService.Infrastructure.Repositories;

using OrderService.Domain.Entities;
using OrderService.Domain.Interfaces;

public class InMemoryOrderRepository : IOrderRepository
{
    private static readonly List<Order> _orders = new();

    public Task<IEnumerable<Order>> GetOrdersByUserAsync(Guid userId) =>
        Task.FromResult(_orders.Where(o => o.UserId == userId).AsEnumerable());

    public Task<Order?> GetByIdAsync(Guid id) =>
        Task.FromResult(_orders.FirstOrDefault(o => o.Id == id));

    public Task CreateAsync(Order order)
    {
        _orders.Add(order);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Order order)
    {
        var index = _orders.FindIndex(o => o.Id == order.Id);
        if (index >= 0)
            _orders[index] = order;
        return Task.CompletedTask;
    }

    public Task<List<Order>> GetByDateAsync(DateTime date)
    {
        var result = _orders.Where(o => o.OrderDate.Date == date.Date).ToList();
        return Task.FromResult(result);
    }

}
