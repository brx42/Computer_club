namespace Computer_club.Services.Services.UserServices.UserService;

public interface IUserService<T>
{
    Task<List<T>> GetAllAsync(int perPage, int page, CancellationToken token);
    Task<T?> GetByIdAsync(Guid id);
    Task<T> AddAsync(T entity, CancellationToken token);
    Task UpdateAsync(T entity, CancellationToken token);
    Task DeleteAsync(T entity);
}