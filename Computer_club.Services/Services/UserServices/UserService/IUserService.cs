using Computer_club.Services.Options;

namespace Computer_club.Services.Services.UserServices.UserService;

public interface IUserService<T>
{
    Task<List<T>> GetAllAsync(Pagination pagination, CancellationToken token);
    Task<T?> GetByIdAsync(Guid id);
    Task<T> AddAsync(T entity, CancellationToken token);
    Task<T> UpdateAsync(T entity, CancellationToken token);
    Task<T> DeleteAsync(T entity);
}