using Computer_club.Domain.Options;

namespace Computer_club.Domain.Repositories.UserRepository;

public interface IUserRepository<T>
{
    Task<List<T>> GetAllAsync(Pagination pagination, CancellationToken token);
    Task<T?> GetByIdAsync(Guid id);
    Task<T> AddAsync(T entity, CancellationToken token);
    Task<T> UpdateAsync(T entity, CancellationToken token);
    Task<T> DeleteAsync(T entity);
}