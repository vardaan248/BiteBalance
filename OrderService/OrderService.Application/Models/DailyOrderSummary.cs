public class DailyOrderSummary
{
    public DateTime Date { get; set; }
    public int TotalOrders { get; set; }
    public int CancelledOrders { get; set; }
    public decimal TotalRevenue { get; set; }
}
