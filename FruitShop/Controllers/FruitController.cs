using Application.DTOs.FruitDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FruitShop.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FruitController(IFruitService fruitService)
    : ControllerBase
{
    private readonly IFruitService _fruitService = fruitService;
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _fruitService.GetAllAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(AddFruitDto dto)
    {
        await _fruitService.AddAsync(dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _fruitService.DeleteAsync(id);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _fruitService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(FruitDto dto)
    {
        await _fruitService.UpdateAsync(dto);
        return Ok();
    }
}
