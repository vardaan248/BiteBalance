namespace InventoryService.Infrastructure.Repositories;

using InventoryService.Domain.Entities;
using InventoryService.Domain.Interfaces;

public class InMemoryInventoryRepository : IInventoryRepository
{
    private static readonly List<Item> _items = new();

    public Task<IEnumerable<Item>> GetAllAsync() => Task.FromResult(_items.AsEnumerable());

    public Task<Item?> GetByNameAsync(string name) =>
        Task.FromResult(_items.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));

    public Task<bool> UpdateQuantityAsync(string name, int change)
    {
        var item = _items.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (item == null || item.QuantityAvailable + change < 0) return Task.FromResult(false);
        item.QuantityAvailable += change;
        return Task.FromResult(true);
    }

    public Task AddAsync(Item item)
    {
        item.Id = Guid.NewGuid();
        _items.Add(item);
        return Task.CompletedTask;
    }
}
