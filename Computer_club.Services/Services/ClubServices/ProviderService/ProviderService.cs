using Computer_club.Data.Database;
using Computer_club.Data.Models.ClubModels;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Services.Services.ClubServices.ProviderService;

public class ProviderService : IProviderService<Provider>
{
    private readonly AppDbContext _context;

    public ProviderService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Provider>> GetAllAsync(CancellationToken token)
    {
        return await _context.Providers.ToListAsync(token);
    }

    public async Task<Provider?> GetByIdAsync(int id)
    {
        return await _context.Providers.FindAsync(id);
    }

    public async Task<Provider> AddAsync(Provider entity, CancellationToken token)
    {
        await _context.Providers.AddAsync(entity, token);
        await _context.SaveChangesAsync(token);
        return entity;
    }

    public async Task UpdateAsync(Provider entity, CancellationToken token)
    {
        _context.Providers.Update(entity);
        await _context.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(Provider entity, CancellationToken token)
    {
        _context.Providers.Remove(entity);
        await _context.SaveChangesAsync(token);
    }
}