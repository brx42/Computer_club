namespace Computer_club.Services.Services.ClubServices.HistoryEquipmentService;

public interface IHistoryEquipService<T>
{
    Task<List<T>?> GetAllAsync(CancellationToken token);
    Task<T?> GetByIdAsync(int id, CancellationToken token);
    Task<T> AddAsync(T entity, CancellationToken token);
    Task UpdateAsync(T entity, CancellationToken token);
    Task DeleteAsync(T entity, CancellationToken token);
}