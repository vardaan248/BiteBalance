using InventoryService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly InventoryService.Application.Services.InventoryService _inventoryService;

    public InventoryController(InventoryService.Application.Services.InventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _inventoryService.GetAllAsync());

    [HttpPost("restock")]
    public async Task<IActionResult> Restock([FromBody] InventoryInput input)
    {
        await _inventoryService.RestockAsync(input.Name, input.Quantity);
        return Ok("Stock updated.");
    }

    [HttpPost("consume")]
    public async Task<IActionResult> Consume([FromBody] InventoryInput input)
    {
        var result = await _inventoryService.ConsumeAsync(input.Name, input.Quantity);
        return result ? Ok("Stock reduced.") : BadRequest("Insufficient stock or item not found.");
    }

    [HttpPost("new-item")]
    public async Task<IActionResult> AddNew([FromBody] InventoryItem item)
    {
        await _inventoryService.AddNewItemAsync(item.Name, item.Unit, item.QuantityAvailable);
        return Ok("Item added.");
    }
}
