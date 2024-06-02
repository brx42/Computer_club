using ComputerClub.DAL.Database;
using ComputerClub.Domain.Options;
using Microsoft.EntityFrameworkCore;

namespace ComputerClub.Domain.Repositories.BaseClubRepository;

public class BaseClubRepository<TEntity, TContext> : IBaseClubRepository<TEntity>
    where TEntity : class
    where TContext : ApplicationDbContext
{
    private readonly TContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public BaseClubRepository(TContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<List<TEntity>> GetAllAsync(Pagination pagination, CancellationToken token)
    {
        return await _dbSet.Skip(pagination.Skip).Take(pagination.Take).ToListAsync(token);
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken token = new())
    {
        await _dbSet.AddAsync(entity, token);
        await _context.SaveChangesAsync(token);
        return entity;
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken token)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken token)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync(token);
    }
}