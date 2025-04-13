namespace InventoryService.Application.Models;

public class InventoryInput
{
    public string Name { get; set; } = default!;
    public double Quantity { get; set; }
}
