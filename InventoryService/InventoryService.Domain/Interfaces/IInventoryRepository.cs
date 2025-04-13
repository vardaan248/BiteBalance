namespace InventoryService.Domain.Interfaces;

public interface IInventoryRepository
{
    Task<IEnumerable<InventoryItem>> GetAllAsync();
    Task<InventoryItem?> GetByNameAsync(string name);
    Task AddAsync(InventoryItem item);
    Task<bool> UpdateQuantityAsync(string name, double change);
}
