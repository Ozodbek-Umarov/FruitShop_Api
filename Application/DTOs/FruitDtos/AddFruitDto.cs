using Domain.Entities;

namespace Application.DTOs.FruitDtos;

public class AddFruitDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; }
    public static implicit operator Fruit(AddFruitDto dto)
    {
        return new Fruit()
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
        };
    }
}
