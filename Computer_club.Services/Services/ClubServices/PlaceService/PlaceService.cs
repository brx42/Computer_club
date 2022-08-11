using Computer_club.Data.Database;
using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Options;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Services.Services.ClubServices.PlaceService;

public class PlaceService : IPlaceService<Place>
{
    private readonly AppDbContext _context;

    public PlaceService(AppDbContext context)
    {
        _context = context;
    }
    

    public async Task<List<Place>> GetAllAsync(Pagination pagination,CancellationToken token)
    {
        return await _context.Places
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync(token);
    }

    public async Task<List<Place>> GetAllFreeSeatsAsync(Pagination pagination, CancellationToken token)
    {
        return await _context.Places
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .Where(x => x.IsFree == true)
            .ToListAsync(token);
    }

    public async Task<List<Place>> GetAllBusySeatsAsync(Pagination pagination, CancellationToken token)
    {
        return await _context.Places
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .Where(x => x.IsFree != true)
            .ToListAsync(token);
    }

    public async Task<List<Place>> GetAllVipSeatsAsync(Pagination pagination, CancellationToken token)
    {
        return await _context.Places
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .Where(x => x.IsVip == true)
            .ToListAsync(token);
    }

    public async Task<List<Place>> GetAllSimpleSeatsAsync(Pagination pagination, CancellationToken token)
    {
        return await _context.Places
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .Where(x => x.IsVip != true)
            .ToListAsync(token);
    }

    public async Task<Place?> GetByIdAsync(int id)
    {
        return await _context.Places.FindAsync(id);
    }

    public async Task<Place> AddAsync(Place place, CancellationToken token)
    {
        await _context.Places.AddAsync(place, token);
        await _context.SaveChangesAsync(token);
        return place;
    }

    public async Task UpdateAsync(Place place, CancellationToken token)
    {
        _context.Places.Update(place);
        await _context.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(Place place, CancellationToken token)
    {
        _context.Places.Remove(place);
        await _context.SaveChangesAsync(token);
    }
}