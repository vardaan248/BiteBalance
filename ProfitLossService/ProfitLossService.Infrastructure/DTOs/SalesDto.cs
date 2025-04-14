namespace ProfitLossService.Infrastructure.DTOs;

public class SalesDto
{
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; } = default!;
}
