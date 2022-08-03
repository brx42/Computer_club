namespace Computer_club.Services.Services.ClubServices.ScheduleService;

public interface IScheduleService<T>
{
    Task<List<T>> GetAllAsync(CancellationToken token);
    Task<T?> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity, CancellationToken token);
    Task DeleteAsync(T entity, CancellationToken token);
}