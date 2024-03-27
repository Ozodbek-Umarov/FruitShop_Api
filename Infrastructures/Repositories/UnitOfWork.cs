using Infrastructures.Interfaces;

namespace Infrastructures.Repositories;

public class UnitOfWork(AppDbContext dbContext)
    : IUnitOfWork
{
    private readonly AppDbContext dbContext = dbContext;

    public ICategoryInterface Category => new CategoryRepository(dbContext);

    public IFruitInterface Fruit => new FruitRepository(dbContext);
}
