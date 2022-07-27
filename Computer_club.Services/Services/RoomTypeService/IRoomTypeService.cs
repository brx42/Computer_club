using Computer_club.Data.Models.Club;

namespace Computer_club.Services.Services.RoomTypeService;

public interface IRoomTypeService<T>
{
    Task<List<T>> GetAllAsync(CancellationToken token);
    Task<RoomType?> GetByIdAsync(Guid id, CancellationToken token);
    Task<T>? AddAsync(T entity, CancellationToken token);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}