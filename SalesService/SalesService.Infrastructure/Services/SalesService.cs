using SalesService.Application.Interfaces;
using SalesService.Application.Models;
using SalesService.Domain.Entities;
using SalesService.Domain.Interfaces;

namespace SalesService.Infrastructure.Services
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository _repository;

        public SalesService(ISalesRepository repository)
        {
            _repository = repository;
        }

        public async Task AddSaleAsync(Guid orderId, decimal amount, string type)
        {
            var sale = new SaleRecord
            {
                OrderId = orderId,
                Amount = amount,
                Type = type,
                Date = DateTime.UtcNow
            };

            await _repository.AddAsync(sale);
        }

        public async Task<SalesSummary> GetSummaryAsync(DateTime date)
        {
            var sales = await _repository.GetByDateAsync(date);

            return new SalesSummary
            {
                Date = date,
                TotalSales = sales.Sum(s => s.Amount),
                TotalTransactions = sales.Count()
            };
        }

        public async Task<decimal> GetDailySalesAsync(DateTime date)
        {
            var sales = await _repository.GetByDateAsync(date);

            var dailySales = sales
                .Where(s => s.Date.Date == date.Date)
                .Sum(s => s.Amount);

            return await Task.FromResult(dailySales);
        }

    }

}
