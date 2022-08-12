namespace Computer_club.Services.Services.ClubServices.PlaceService;

public interface IPlaceService<T>
{
    Task<List<T>> GetAllAsync(int pageNumber, int pageSize, CancellationToken token);
    Task<List<T>> GetAllFreeSeatsAsync(int pageNumber, int pageSize, CancellationToken token);
    Task<List<T>> GetAllBusySeatsAsync(int pageNumber, int pageSize, CancellationToken token);
    Task<List<T>> GetAllVipSeatsAsync(int pageNumber, int pageSize, CancellationToken token);
    Task<List<T>> GetAllSimpleSeatsAsync(int pageNumber, int pageSize, CancellationToken token);
    Task<List<T>> GetAllFreePlacesForTypeAsync(int pageNumber, int pageSize, string name);
    Task<T?> GetByIdAsync(int id);
    Task<T> AddAsync(T entity, CancellationToken token);
    Task UpdateAsync(T entity, CancellationToken token);
    Task DeleteAsync(T entity, CancellationToken token);
}