using Domain.Entities;
using Infrastructures.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories;

public class FruitRepository(AppDbContext dbContext)
    : IFruitInterface
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task AddAsync(Fruit fruit)
    {
        _dbContext.Fruit.AddAsync(fruit);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var fruit = await _dbContext.Fruit.FindAsync(id);
        if (fruit != null)
        {
            _dbContext.Fruit.Remove(fruit);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<List<Fruit>> GetAllAsync()
    {
        return await _dbContext.Fruit.ToListAsync();
    }

    public async Task<Fruit> GetByIdAsync(int id)
    {
        return await _dbContext.Fruit.FindAsync(id);
    }

    public Task UpdateAsync(Fruit fruit)
    {
        throw new NotImplementedException();
    }
}
