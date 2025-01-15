using Microsoft.AspNetCore.Mvc;
using RecordShop.Services.Implementations;

namespace RecordShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StockController(StockService service) : ControllerBase
{
    private readonly StockService _service = service;

    [HttpGet]
    public IActionResult GetStock()
    {
        var result = _service.GetStock();
        if(result == null) return NotFound();
        else return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetStockById(int id)
    {
        var result = _service.GetStockById(id);
        if(result == null) return NotFound();
        else return Ok(result);
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateStock(int id, [FromBody]int quantity)
    {
        var result = _service.UpdateStock(id, quantity);
        if(result == null) return BadRequest();
        return Ok(result);
    }
}
