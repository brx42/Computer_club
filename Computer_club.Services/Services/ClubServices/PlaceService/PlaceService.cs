using Computer_club.Data.Database;
using Computer_club.Data.Models.ClubModels;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Services.Services.ClubServices.PlaceService;

public class PlaceService : IPlaceService<Place>
{
    private readonly AppDbContext _context;

    public PlaceService(AppDbContext context)
    {
        _context = context;
    }
    

    public async Task<List<Place>> GetAllAsync(CancellationToken token)
    {
        return await _context.Places.ToListAsync(token);
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