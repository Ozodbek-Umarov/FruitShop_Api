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
        _dbContext.Fruits.AddAsync(fruit);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Fruit fruit)
    {
        _dbContext.Fruits.Remove(fruit);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Fruit>> GetAllAsync()
    {
        return await _dbContext.Fruits.ToListAsync();
    }

    public async Task<Fruit> GetByIdAsync(int id)
    {
        return await _dbContext.Fruits.FindAsync(id);
    }

    public async Task UpdateAsync(Fruit fruit)
    {
        _dbContext.Fruits.Update(fruit);
        await _dbContext.SaveChangesAsync();
    }
}
