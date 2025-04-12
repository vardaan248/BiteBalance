namespace InventoryService.Domain.Interfaces;

using InventoryService.Domain.Entities;

public interface IInventoryRepository
{
    Task<IEnumerable<Item>> GetAllAsync();
    Task<Item?> GetByNameAsync(string name);
    Task<bool> UpdateQuantityAsync(string name, int change);
    Task AddAsync(Item item);
}
