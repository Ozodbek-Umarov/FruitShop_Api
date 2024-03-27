using Domain.Entities;

namespace Infrastructures.Interfaces;

public interface ICategoryInterface
{
    Task<List<Category>> GetAllAsync();
    Task<Category> GetByIdAsync(int id);
    Task AddAsync(Category category);
    Task DeleteAsync(int id);
    Task UpdateAsync(Category category);
}
