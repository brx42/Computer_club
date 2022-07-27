using Computer_club.Data.Data;
using Computer_club.Data.Models.Club;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Services.Services.ClubServices.DescriptionService;

public class DescriptionService : IDescriptionService<DescriptionClub>
{
    private readonly AppDbContext _context;

    public DescriptionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<DescriptionClub>> GetAllAsync(CancellationToken token)
    {
        return await _context.DescriptionClubs.ToListAsync(token);
    }

    public async Task<DescriptionClub?> GetByIdAsync(Guid id)
    {
        return await _context.DescriptionClubs.FindAsync(id);
    }

    public async Task<DescriptionClub?> AddAsync(DescriptionClub description)
    {
        await _context.DescriptionClubs.AddAsync(description);
        await _context.SaveChangesAsync();
        return description;
    }

    public async Task UpdateAsync(DescriptionClub description, CancellationToken token)
    {
        _context.DescriptionClubs.Update(description);
        await _context.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(DescriptionClub description, CancellationToken token)
    {
        _context.DescriptionClubs.Remove(description);
        await _context.SaveChangesAsync(token);
    }
}