using Domain.Entities;

namespace Infrastructures.Interfaces;

public interface ICategoryInterface
{
    Task<List<Category>> GetAllAsync();
    Task<Category> GetByIdAsync(int id);
    Task AddAsync(Category category);
    Task DeleteAsync(Category category);
    Task UpdateAsync(Category category);
}
