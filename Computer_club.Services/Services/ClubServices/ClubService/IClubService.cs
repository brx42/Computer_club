﻿namespace Computer_club.Services.Services.ClubServices.ClubService;

public interface IClubService<T>
{
    Task<IEnumerable<string>?> FindAddressAsync(string entity);
    Task<List<T>?> GetAllAsync(CancellationToken token);
    Task<T?> GetByIdAsync(int id);
    Task<T?> AddAsync(T entity);
    Task UpdateAsync(T entity, CancellationToken token);
    Task DeleteAsync(T entity);
}