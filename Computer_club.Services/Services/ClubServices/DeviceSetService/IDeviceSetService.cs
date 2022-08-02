namespace Computer_club.Services.Services.ClubServices.DeviceSetService;

public interface IDeviceSetService<T>
{
    Task<List<T>> GetAllAsync(CancellationToken token);
    Task<T?> GetByIdAsync(int id);
    Task<T> AddAsync(T entity, CancellationToken token);
    Task UpdateAsync(T entity, CancellationToken token);
    Task DeleteAsync(T entity, CancellationToken token);
}