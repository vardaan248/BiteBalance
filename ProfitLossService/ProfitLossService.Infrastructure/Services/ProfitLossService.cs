using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using ProfitLossService.Application.Interfaces;
using ProfitLossService.Domain.Models;
using ProfitLossService.Infrastructure.DTOs;

namespace ProfitLossService.Infrastructure.Services;

public class ProfitLossService : IProfitLossService
{
    private readonly HttpClient _httpClient;
    private readonly string _salesUrl;
    private readonly string _inventoryUrl;

    public ProfitLossService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _salesUrl = config["ServiceUrls:SalesService"]!;
        _inventoryUrl = config["ServiceUrls:InventoryService"]!;
    }

    public async Task<ProfitLossSummary> GetDailySummaryAsync(DateTime date)
    {
        var formattedDate = date.ToString("yyyy-MM-dd");

        var sales = await _httpClient.GetFromJsonAsync<List<SalesDto>>($"sales/daily/{formattedDate}");
        var cost = await _httpClient.GetFromJsonAsync<decimal>($"inventory/cost/daily/{formattedDate}");

        var revenue = sales?.Sum(s => s.Amount) ?? 0;

        return new ProfitLossSummary
        {
            Date = date,
            TotalRevenue = revenue,
            TotalCost = cost
        };
    }

    public async Task<ProfitLossSummary> GetMonthlySummaryAsync(int month, int year)
    {
        var sales = await _httpClient.GetFromJsonAsync<List<SalesDto>>($"sales/monthly/{month}/{year}");
        var cost = await _httpClient.GetFromJsonAsync<decimal>($"inventory/cost/monthly/{month}/{year}");

        var revenue = sales?.Sum(s => s.Amount) ?? 0;

        return new ProfitLossSummary
        {
            Date = new DateTime(year, month, 1),
            TotalRevenue = revenue,
            TotalCost = cost
        };
    }
}
