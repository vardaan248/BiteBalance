using Microsoft.AspNetCore.Mvc;
using ProfitLossService.Application.Interfaces;
using ProfitLossService.Domain.Models;

namespace ProfitLossService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfitLossController : ControllerBase
{
    private readonly IProfitLossService _profitLossService;

    public ProfitLossController(IProfitLossService profitLossService)
    {
        _profitLossService = profitLossService;
    }

    [HttpGet("daily")]
    public async Task<ActionResult<ProfitLossSummary>> GetDaily([FromQuery] DateTime date)
    {
        var result = await _profitLossService.GetDailySummaryAsync(date);
        return Ok(result);
    }

    [HttpGet("monthly")]
    public async Task<ActionResult<ProfitLossSummary>> GetMonthly([FromQuery] int month, [FromQuery] int year)
    {
        var result = await _profitLossService.GetMonthlySummaryAsync(month, year);
        return Ok(result);
    }
}
