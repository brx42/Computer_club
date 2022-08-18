using Computer_club.Domain.Options;

namespace Computer_club.Domain.Repositories.BaseClubRepository;

public interface IBaseClubRepository<TEntity>
{
    Task<List<TEntity>> GetAllAsync(Pagination pagination, CancellationToken token);
    Task<TEntity?> GetByIdAsync(int id);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken token = new());
    Task UpdateAsync(TEntity entity, CancellationToken token);
    Task DeleteAsync(TEntity entity, CancellationToken token);
}