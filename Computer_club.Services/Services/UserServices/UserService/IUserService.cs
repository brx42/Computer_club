namespace Computer_club.Services.Services.UserServices.UserService;

public interface IUserService<T>
{
    Task<List<T>> GetAllAsync(int page, int limit, CancellationToken token);
    Task<T?> GetByIdAsync(Guid id);
    Task<T> AddAsync(T entity, CancellationToken token);
    Task<T> UpdateAsync(T entity, CancellationToken token);
    Task<T> DeleteAsync(T entity);
}