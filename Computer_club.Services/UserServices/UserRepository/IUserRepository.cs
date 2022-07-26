namespace Computer_club.Services.UserServices.UserRepository;

public interface IUserRepository<T>
{
    Task<List<T>> GetAllAsync(CancellationToken token);

    Task<T?> GetByIdAsync(Guid id);

    Task<T> AddAsync(T entity, CancellationToken token);

    Task UpdateAsync(T entity, CancellationToken token);

    Task DeleteAsync(T entity);
}