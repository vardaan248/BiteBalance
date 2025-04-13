using InventoryService.Domain.Interfaces;

namespace InventoryService.Infrastructure.Repositories;

public class InMemoryInventoryRepository : IInventoryRepository
{
    private static readonly List<InventoryItem> _items = new();

    public Task<IEnumerable<InventoryItem>> GetAllAsync() =>
        Task.FromResult(_items.AsEnumerable());

    public Task<InventoryItem?> GetByNameAsync(string name) =>
        Task.FromResult(_items.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));

    public Task AddAsync(InventoryItem item)
    {
        item.Id = Guid.NewGuid();
        _items.Add(item);
        return Task.CompletedTask;
    }

    public Task<bool> UpdateQuantityAsync(string name, double change)
    {
        var item = _items.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (item == null || item.QuantityAvailable + change < 0)
            return Task.FromResult(false);

        item.QuantityAvailable += change;
        return Task.FromResult(true);
    }
}
