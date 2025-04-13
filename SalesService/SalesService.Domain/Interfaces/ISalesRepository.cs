using SalesService.Domain.Entities;

namespace SalesService.Domain.Interfaces
{
    public interface ISalesRepository
    {
        Task AddAsync(SaleRecord sale);
        Task<IEnumerable<SaleRecord>> GetByDateAsync(DateTime date);
    }
}
