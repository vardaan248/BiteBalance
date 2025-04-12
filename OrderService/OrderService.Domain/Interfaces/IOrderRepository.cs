namespace OrderService.Domain.Interfaces;

using OrderService.Domain.Entities;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetOrdersByUserAsync(Guid userId);
    Task<Order?> GetByIdAsync(Guid id);
    Task CreateAsync(Order order);
    Task UpdateAsync(Order order);
}
