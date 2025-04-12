namespace OrderService.Domain.Entities;

public class Order
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string[] Items { get; set; } = [];
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "Pending";
    public string? PaymentMethod { get; set; }
    public DateTime? EstimatedDeliveryTime { get; set; }
}
