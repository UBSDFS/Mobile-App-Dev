
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerformanceAPI.Data;
using PerformanceAPI.Models;

namespace PerformanceAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly AppDbContext _database;

    public ItemsController(AppDbContext database)
    {
        _database = database;
    }

    // GET: api/items
    [HttpGet]
    public async Task<ActionResult<List<Item>>> GetItems()
    {
        return await _database.Items.ToListAsync();
    }

    // POST: api/items
    [HttpPost]
    public async Task<ActionResult<Item>> SaveItem(Item item)
    {
        if (string.IsNullOrWhiteSpace(item.ItemName) ||
            string.IsNullOrWhiteSpace(item.ItemDescription))
        {
            return BadRequest("All fields are required.");
        }

        if (item.ItemId <= 0)
        {
            return BadRequest("A valid Item ID is required.");
        }

        if (await _database.Items.AnyAsync(x => x.ItemId == item.ItemId))
        {
            return Conflict("Item ID already exists.");
        }

        _database.Items.Add(item);
        await _database.SaveChangesAsync();

        return Ok(item);
    }
}
