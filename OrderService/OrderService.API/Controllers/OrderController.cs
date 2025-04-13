using Microsoft.AspNetCore.Mvc;
using OrderService.Domain.Entities;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class OrderController : ControllerBase
{
    private readonly OrderService.Application.Services.OrderService _orderService;

    public OrderController(OrderService.Application.Services.OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("my")]
    public async Task<IActionResult> MyOrders([FromQuery] string? status)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var orders = await _orderService.GetOrdersByUserAsync(userId);

        if (!string.IsNullOrEmpty(status))
            orders = orders.Where(o => o.Status.Equals(status, StringComparison.OrdinalIgnoreCase));

        return Ok(orders);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody]Order order)
    {
        order.UserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        await _orderService.CreateOrderAsync(order);
        return Ok("Order created successfully!");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        return order == null ? NotFound() : Ok(order);
    }

    [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] string newStatus)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null) return NotFound("Order not found");

        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        if (order.UserId != userId) return Forbid();

        order.Status = newStatus;
        await _orderService.UpdateOrderAsync(order);

        return Ok("Order status updated");
    }

    [HttpGet("summary")]
    public async Task<IActionResult> GetSummary([FromQuery] DateTime date)
    {
        var summary = await _orderService.GetSummaryAsync(date);
        return Ok(summary);
    }

}
