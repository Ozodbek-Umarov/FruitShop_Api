using Domain.Entities;

namespace Infrastructures.Interfaces;

public interface IUserInterface
{
    Task<List<User>> GetAllAsync();
    Task<User> GetByIdAsync(int id);
    Task AddAsync(User user);
    Task DeleteAsync(User user);  
    Task UpdateAsync(User user);
    Task<User> GetByEmailAsync(string email);
}
