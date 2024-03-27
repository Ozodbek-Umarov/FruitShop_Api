using Application.DTOs.FruitDtos;

namespace Application.Interfaces;

public interface IFruitService
{
    Task<List<FruitDto>> GetAllAsync();
    Task<FruitDto> GetByIdAsync(int id);
    Task AddAsync(AddFruitDto dto);
    Task UpdateAsync(FruitDto dto);
    Task DeleteAsync(int id);
}
