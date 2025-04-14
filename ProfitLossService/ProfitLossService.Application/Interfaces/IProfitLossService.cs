using ProfitLossService.Domain.Models;

namespace ProfitLossService.Application.Interfaces;

public interface IProfitLossService
{
    Task<ProfitLossSummary> GetDailySummaryAsync(DateTime date);
    Task<ProfitLossSummary> GetMonthlySummaryAsync(int month, int year);
}
