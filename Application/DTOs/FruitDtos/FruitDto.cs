using Domain.Entities;

namespace Application.DTOs.FruitDtos;

public class FruitDto : AddFruitDto
{
    public int Id { get; set; }
    public static implicit operator FruitDto(Fruit fruit)
        => new()
        {
            Id = fruit.Id,
            Name = fruit.Name,
            Description = fruit.Description,
            Price = fruit.Price,
        };
}
