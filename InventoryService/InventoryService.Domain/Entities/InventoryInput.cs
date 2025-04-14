namespace InventoryService.Domain.Entities;

public class InventoryInput
{
    public string Name { get; set; }
    public double Quantity { get; set; }
    public decimal PricePerUnit { get; set; }
    public DateTime Date { get; set; }
}
