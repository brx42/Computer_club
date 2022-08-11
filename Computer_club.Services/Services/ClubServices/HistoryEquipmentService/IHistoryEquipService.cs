using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Options;

namespace Computer_club.Services.Services.ClubServices.HistoryEquipmentService;

public interface IHistoryEquipService<T>
{
    Task<List<T>?> GetAllAsync(CancellationToken token);
    Task<List<T>?> GetAllForThePeriodAsync(Pagination pagination, DateTime start, DateTime end);
    Task<T?> GetByIdAsync(int id);
    Task<T> AddAsync(T entity, CancellationToken token);
    Task UpdateAsync(T entity, CancellationToken token);
    Task DeleteAsync(T entity, CancellationToken token);
}