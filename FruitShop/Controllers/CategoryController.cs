using Application.DTOs.CategoryDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitShop.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(ICategoryService categoryService)
    : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _categoryService.GetAllAsync();
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> AddAsync(AddCategoryDto dto)
    {
        await _categoryService.AddAsync(dto);
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _categoryService.DeleteAsync(id);
        return Ok();
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _categoryService.GetByIdAsync(id);
        return Ok(result);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(CategoryDto dto)
    {
        await _categoryService.UpdateAsync(dto);
        return Ok();
    }
}
