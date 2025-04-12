namespace InventoryService.Application.Services;

using global::InventoryService.Domain.Entities;
using global::InventoryService.Domain.Interfaces;

public class InventoryService
{
    private readonly IInventoryRepository _repo;

    public InventoryService(IInventoryRepository repo)
    {
        _repo = repo;
    }

    public Task<IEnumerable<Item>> GetAllItemsAsync() => _repo.GetAllAsync();

    public Task<Item?> GetItemByNameAsync(string name) => _repo.GetByNameAsync(name);

    public Task<bool> ReduceStockAsync(string name, int quantity) =>
        _repo.UpdateQuantityAsync(name, -quantity);

    public Task AddItemAsync(Item item) => _repo.AddAsync(item);
}
