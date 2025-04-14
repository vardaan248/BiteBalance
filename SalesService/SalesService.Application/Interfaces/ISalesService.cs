using SalesService.Application.Models;

namespace SalesService.Application.Interfaces
{
    public interface ISalesService
    {
        Task AddSaleAsync(Guid orderId, decimal amount, string type);
        Task<SalesSummary> GetSummaryAsync(DateTime date);
        Task<decimal> GetDailySalesAsync(DateTime date);
    }
}
