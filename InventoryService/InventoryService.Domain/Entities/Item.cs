namespace InventoryService.Domain.Entities;

public class Item
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public int QuantityAvailable { get; set; }
}
