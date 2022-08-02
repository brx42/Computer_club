namespace Computer_club.Services.Services.ClubServices.EquipmentService;

public interface IEquipmentService<T>
{
    Task<List<T>> GetAllAsync(CancellationToken token);
    Task<T?> GetByIdAsync(int id);
    Task<T> AddAsync(T entity, CancellationToken token);
    Task UpdateAsync(T entity, CancellationToken token);
    Task DeleteAsync(T entity, CancellationToken token);
}