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
        Ok(await _inventoryService.GetAllItemsAsync());

    [HttpPost("add")]
    public async Task<IActionResult> Add(Item item)
    {
        await _inventoryService.AddItemAsync(item);
        return Ok("Item added");
    }

    [HttpPatch("reduce")]
    public async Task<IActionResult> Reduce([FromQuery] string name, [FromQuery] int quantity)
    {
        var result = await _inventoryService.ReduceStockAsync(name, quantity);
        return result ? Ok("Stock reduced") : BadRequest("Insufficient stock or item not found");
    }
}
