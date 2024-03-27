using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet <Fruit> Fruit { get; set; }
    public DbSet <Category> Categories { get; set; }
}
