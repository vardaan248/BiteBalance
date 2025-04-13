using Microsoft.AspNetCore.Mvc;
using SalesService.Domain.Entities;

namespace SalesService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly SalesService.Application.Services.SalesService _salesService;

        public SalesController(SalesService.Application.Services.SalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpPost]
        public async Task<IActionResult> AddSale([FromBody] SaleRecord sale)
        {
            await _salesService.AddSaleAsync(sale.OrderId, sale.Amount, sale.Type);
            return Ok("Sale added");
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary([FromQuery] DateTime date)
        {
            var result = await _salesService.GetSummaryAsync(date);
            return Ok(result);
        }
    }

}
