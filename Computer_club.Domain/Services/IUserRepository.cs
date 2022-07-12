namespace Computer_club.Domain.Services;

public interface IUserRepository<T>
{
    Task<List<T>> GetAllAsync(CancellationToken token);

    Task<T?> GetByIdAsync(Guid id, CancellationToken token);

    Task<T> AddAsync(T entity, CancellationToken token);

    Task UpdateAsync(T entity, CancellationToken token);

    Task DeleteAsync(T entity, CancellationToken token);
}