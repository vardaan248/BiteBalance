namespace SalesService.Domain.Entities
{
    public class SaleRecord
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } = "Order"; // Order or Subscription
        public DateTime Date { get; set; }
    }
}
