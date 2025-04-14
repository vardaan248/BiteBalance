namespace ProfitLossService.Domain.Models
{
    public class ProfitLossSummary
    {
        public DateTime Date { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalCost { get; set; }
        public decimal NetProfit => TotalRevenue - TotalCost;
    }

}
