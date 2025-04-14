namespace InventoryService.Application.Interfaces
{
    public interface IInventoryService
    {
        Task<IEnumerable<InventoryItem>> GetAllAsync();

        Task<bool> ConsumeAsync(string name, double quantity);

        Task RestockAsync(string name, double quantity);

        Task AddNewItemAsync(string name, string unit, double quantity);

        //Task<decimal> GetDailyInventoryCostAsync(DateTime date);
    }
}
