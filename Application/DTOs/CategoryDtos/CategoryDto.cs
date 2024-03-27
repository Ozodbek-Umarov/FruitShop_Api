using Domain.Entities;

namespace Application.DTOs.CategoryDtos;

public class CategoryDto : AddCategoryDto
{
    public int Id { get; set; }
    public static implicit operator CategoryDto(Category category)
        => new()
        {
            Id = category.Id,
            Name = category.Name,
        };
}
