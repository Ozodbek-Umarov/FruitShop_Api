﻿using Domain.Entities;

namespace Infrastructures.Interfaces;

public interface IFruitInterface
{
    Task<List<Fruit>> GetAllAsync();
    Task<Fruit> GetByIdAsync (int id);
    Task AddAsync (Fruit fruit);
    Task DeleteAsync (int id);
    Task UpdateAsync (Fruit fruit);
}
