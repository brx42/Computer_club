using Computer_club.Data.Models.Club;

namespace Computer_club.Services.Services.ClubServices.DescriptionServices;

public interface IDescriptionService<T>
{
    Task<List<T>> GetAllAsync(CancellationToken token);
    Task<T?> GetByIdAsync(Guid id);
    Task<T?> AddAsync(T entity);
    Task UpdateAsync(T entity, CancellationToken token);
    Task DeleteAsync(T entity, CancellationToken token);
}