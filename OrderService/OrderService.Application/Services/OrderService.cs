namespace OrderService.Application.Services;

using Common.Common.HttpClients.Sales;
using global::OrderService.Domain.Entities;
using global::OrderService.Domain.Interfaces;

public class OrderService
{
    private readonly IOrderRepository _repository;
    private SalesHttpClient _salesHttpClient;

    public OrderService(IOrderRepository repository, SalesHttpClient salesHttpClient)
    {
        _repository = repository;
        _salesHttpClient = salesHttpClient;
    }

    public Task<IEnumerable<Order>> GetOrdersByUserAsync(Guid userId) => _repository.GetOrdersByUserAsync(userId);

    public Task<Order?> GetOrderByIdAsync(Guid id) => _repository.GetByIdAsync(id);

    public async Task CreateOrderAsync(Order order)
    {
        order.Id = Guid.NewGuid();
        order.OrderDate = DateTime.UtcNow;
        order.Status = "Pending";
        await _repository.CreateAsync(order);

        await _salesHttpClient.SendSaleAsync(new SaleRecordRequest
        {
            OrderId = order.Id,
            Amount = order.TotalAmount,
            Type = "Order"
        });
    }

    public Task UpdateOrderAsync(Order order) => _repository.UpdateAsync(order);

    public async Task<DailyOrderSummary> GetSummaryAsync(DateTime date)
    {
        var orders = await _repository.GetByDateAsync(date.Date);

        return new DailyOrderSummary
        {
            Date = date.Date,
            TotalOrders = orders.Count,
            CancelledOrders = orders.Count(o => o.Status == "Cancelled"),
            TotalRevenue = orders.Where(o => o.Status != "Cancelled").Sum(o => o.TotalAmount)
        };
    }

}
