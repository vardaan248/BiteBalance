using InventoryService.Application.Interfaces;
using InventoryService.Domain.Interfaces;

namespace InventoryService.Application.Services;

public class InventoryService : IInventoryService
{
    private readonly IInventoryRepository _repository;

    public InventoryService(IInventoryRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<InventoryItem>> GetAllAsync() =>
        _repository.GetAllAsync();

    public Task<bool> ConsumeAsync(string name, double quantity) =>
        _repository.UpdateQuantityAsync(name, -quantity);

    public Task RestockAsync(string name, double quantity) =>
        _repository.UpdateQuantityAsync(name, quantity);

    public async Task AddNewItemAsync(string name, string unit, double quantity)
    {
        var existing = await _repository.GetByNameAsync(name);
        if (existing != null) return; // optional: throw instead

        var item = new InventoryItem
        {
            Name = name,
            Unit = unit,
            QuantityAvailable = quantity
        };

        await _repository.AddAsync(item);
    }

    //public async Task<decimal> GetDailyInventoryCostAsync(DateTime date)
    //{
    //    var totalUsed = _inventoryInputs
    //        .Where(i => i.Date.Date == date.Date)
    //        .Sum(i => i.Quantity * i.PricePerUnit);

    //    return await Task.FromResult(totalUsed);
    //}

}
