using ComputerClub.DAL.Database;
using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.Domain.Options;
using ComputerClub.Domain.Services.ClubServices.DeviceSetService;
using Microsoft.EntityFrameworkCore;

namespace ComputerClub.Domain.Services.ClubServices.PlaceService;

public class PlaceService : IPlaceService<Place>
{
    private readonly ApplicationDbContext _context;
    private readonly IDeviceSetService _device;
    public PlaceService(ApplicationDbContext context, IDeviceSetService device)
    {
        _context = context;
        _device = device;
    }
    
    public async Task<List<Place>> GetAllFreeSeatsAsync(Pagination pagination, CancellationToken token)
    {
        return await _context.Place
            .Skip(pagination.Skip)
            .Take(pagination.Take)
            .Where(x => x.IsFree == true)
            .ToListAsync(token);
    }

    public async Task<List<Place>> GetAllBusySeatsAsync(Pagination pagination, CancellationToken token)
    {
        return await _context.Place
            .Skip(pagination.Skip)
            .Take(pagination.Take)
            .Where(x => x.IsFree != true)
            .ToListAsync(token);
    }

    public async Task<List<Place>> GetAllVipSeatsAsync(Pagination pagination, CancellationToken token)
    {
        return await _context.Place
            .Skip(pagination.Skip)
            .Take(pagination.Take)
            .Where(x => x.IsVip == true)
            .ToListAsync(token);
    }

    public async Task<List<Place>> GetAllSimpleSeatsAsync(Pagination pagination, CancellationToken token)
    {
        return await _context.Place
            .Skip(pagination.Skip)
            .Take(pagination.Take)
            .Where(x => x.IsVip != true)
            .ToListAsync(token);
    }

    public async Task<List<Place>> GetAllFreePlacesForTypeAsync(Pagination pagination, string name)
    {
        DeviceSet? set = await _device.GetDeviceSetForFreePlaces(name);
        return await _context.Place
            .Skip(pagination.Skip)
            .Take(pagination.Take)
            .Where(x => x.IsFree == true && x.DeviceSetId == set.Id)
            .ToListAsync();
    }
}