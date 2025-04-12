namespace OrderService.Application.Services;

using global::OrderService.Domain.Entities;
using global::OrderService.Domain.Interfaces;

public class OrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Order>> GetOrdersByUserAsync(Guid userId) => _repository.GetOrdersByUserAsync(userId);

    public Task<Order?> GetOrderByIdAsync(Guid id) => _repository.GetByIdAsync(id);

    public async Task CreateOrderAsync(Order order)
    {
        order.Id = Guid.NewGuid();
        order.OrderDate = DateTime.UtcNow;
        order.Status = "Pending";
        await _repository.CreateAsync(order);
    }

    public Task UpdateOrderAsync(Order order) => _repository.UpdateAsync(order);
}
