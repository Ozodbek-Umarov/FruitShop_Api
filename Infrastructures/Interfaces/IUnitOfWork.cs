namespace Infrastructures.Interfaces;
public interface IUnitOfWork
{
    ICategoryInterface Category { get; }
    IFruitInterface Fruit { get; }
    IUserInterface User { get; }
}
