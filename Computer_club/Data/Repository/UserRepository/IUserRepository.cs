namespace Computer_club.Data.Repository.UserRepository;

public interface IUserRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken token);

    Task<T?> GetByIdAsync(Guid id, CancellationToken token);

    Task<T> AddAsync(T entity, CancellationToken token);

    Task UpdateAsync(T entity, CancellationToken token);

    Task DeleteAsync(T entity, CancellationToken token);
}