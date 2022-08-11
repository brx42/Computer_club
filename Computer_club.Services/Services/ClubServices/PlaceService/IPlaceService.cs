using Computer_club.Services.Options;

namespace Computer_club.Services.Services.ClubServices.PlaceService;

public interface IPlaceService<T>
{
    Task<List<T>> GetAllAsync(Pagination pagination, CancellationToken token);
    Task<List<T>> GetAllFreeSeatsAsync(Pagination pagination, CancellationToken token);
    Task<List<T>> GetAllBusySeatsAsync(Pagination pagination, CancellationToken token);
    Task<List<T>> GetAllVipSeatsAsync(Pagination pagination, CancellationToken token);
    Task<List<T>> GetAllSimpleSeatsAsync(Pagination pagination, CancellationToken token);
    Task<T?> GetByIdAsync(int id);
    Task<T> AddAsync(T entity, CancellationToken token);
    Task UpdateAsync(T entity, CancellationToken token);
    Task DeleteAsync(T entity, CancellationToken token);
}