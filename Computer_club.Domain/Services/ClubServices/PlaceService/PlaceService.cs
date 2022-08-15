using Computer_club.Data.Database;
using Computer_club.Data.Models.ClubModels;
using Computer_club.Domain.Options;
using Computer_club.Domain.Services.ClubServices.DeviceSetService;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Domain.Services.ClubServices.PlaceService;

public class PlaceService : IPlaceService<Place>
{
    private readonly AppDbContext _context;
    private readonly IDeviceSetService _device;
    public PlaceService(AppDbContext context, IDeviceSetService device)
    {
        _context = context;
        _device = device;
    }
    
    public async Task<List<Place>> GetAllFreeSeatsAsync(Pagination pagination, CancellationToken token)
    {
        return await _context.Places
            .Skip(pagination.Skip)
            .Take(pagination.Take)
            .Where(x => x.IsFree == true)
            .ToListAsync(token);
    }

    public async Task<List<Place>> GetAllBusySeatsAsync(Pagination pagination, CancellationToken token)
    {
        return await _context.Places
            .Skip(pagination.Skip)
            .Take(pagination.Take)
            .Where(x => x.IsFree != true)
            .ToListAsync(token);
    }

    public async Task<List<Place>> GetAllVipSeatsAsync(Pagination pagination, CancellationToken token)
    {
        return await _context.Places
            .Skip(pagination.Skip)
            .Take(pagination.Take)
            .Where(x => x.IsVip == true)
            .ToListAsync(token);
    }

    public async Task<List<Place>> GetAllSimpleSeatsAsync(Pagination pagination, CancellationToken token)
    {
        return await _context.Places
            .Skip(pagination.Skip)
            .Take(pagination.Take)
            .Where(x => x.IsVip != true)
            .ToListAsync(token);
    }

    public async Task<List<Place>> GetAllFreePlacesForTypeAsync(Pagination pagination, string name)
    {
        var set = await _device.GetDeviceSetForFreePlaces(name);
        return await _context.Places
            .Skip(pagination.Skip)
            .Take(pagination.Take)
            .Where(x => x.IsFree == true && x.DeviceSetId == set.Id)
            .ToListAsync();
    }
}