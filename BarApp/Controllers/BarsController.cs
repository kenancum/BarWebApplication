using BarApp.Services;
using BarApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BarStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BarsController : ControllerBase
{
    private readonly IBarService _barsService;

    public BarsController(IBarService barService) =>
        _barsService = barService;

    [HttpGet]
    public async Task<List<Bar>> Get() =>
        await _barsService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Bar>> Get(string id)
    {
        var bar = await _barsService.GetAsync(id);

        if (bar is null)
        {
            return NotFound();
        }

        return bar;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Bar newBar)
    {
        await _barsService.CreateAsync(newBar);

        return CreatedAtAction(nameof(Get), new { id = newBar.Id }, newBar);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Bar updatedBar)
    {
        var bar = await _barsService.GetAsync(id);

        if (bar is null)
        {
            return NotFound();
        }

        updatedBar.Id = bar.Id;

        await _barsService.UpdateAsync(id, updatedBar);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var bar = await _barsService.GetAsync(id);

        if (bar is null)
        {
            return NotFound();
        }

        await _barsService.RemoveAsync(id);

        return NoContent();
    }
}