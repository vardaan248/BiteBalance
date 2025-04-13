using SalesService.Domain.Entities;
using SalesService.Domain.Interfaces;

namespace SalesService.Infrastructure.Repositories
{
    public class InMemorySalesRepository : ISalesRepository
    {
        private readonly List<SaleRecord> _sales = new();

        public Task AddAsync(SaleRecord sale)
        {
            sale.Id = Guid.NewGuid();
            _sales.Add(sale);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<SaleRecord>> GetByDateAsync(DateTime date)
        {
            var result = _sales.Where(s => s.Date.Date == date.Date);
            return Task.FromResult(result);
        }
    }

}
