namespace SalesService.Application.Models
{
    public class SalesSummary
    {
        public DateTime Date { get; set; }
        public decimal TotalSales { get; set; }
        public int TotalTransactions { get; set; }
    }
}
