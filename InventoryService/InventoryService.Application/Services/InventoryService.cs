using InventoryService.Domain.Interfaces;

namespace InventoryService.Application.Services;

public class InventoryService
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
}
