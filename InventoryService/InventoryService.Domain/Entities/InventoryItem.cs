public class InventoryItem
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Unit { get; set; } = "kg"; // or liters, pieces, etc.
    public double QuantityAvailable { get; set; }
}
