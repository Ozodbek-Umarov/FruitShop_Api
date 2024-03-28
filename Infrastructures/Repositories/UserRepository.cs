using Domain.Entities;
using Infrastructures.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories;

public class UserRepository(AppDbContext appDbContext)
    : IUserInterface
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task AddAsync(User user)
    {
        await _appDbContext.Users.AddAsync(user);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        _appDbContext.Users.Remove(user);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<List<User>> GetAllAsync()
        => await _appDbContext.Users.ToListAsync();

    public async Task<User> GetByIdAsync(int id)
        => await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

    public async Task UpdateAsync(User user)
    {
        _appDbContext.Users.Update(user);
        await _appDbContext.SaveChangesAsync();
    }
}
