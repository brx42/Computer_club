using Computer_club.Services.Options;

namespace Computer_club.Services.Services.ClubServices.PhotoService;

public interface IPhotoService<T>
{
    Task<List<T>> GetAllAsync(Pagination pagination, CancellationToken token);
    Task<T?> GetByIdAsync(int id);
    Task<T> AddAsync(T entity, CancellationToken token);
    Task UpdateAsync(T entity, CancellationToken token);
    Task DeleteAsync(T entity, CancellationToken token);
}