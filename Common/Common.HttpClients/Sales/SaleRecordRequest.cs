namespace Common.Common.HttpClients.Sales
{
    public class SaleRecordRequest
    {
        public Guid OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } // "Order" or "Subscription"
    }
}
