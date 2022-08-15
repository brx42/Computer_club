using Computer_club.Data.Database;
using Computer_club.Data.Models.ClubModels;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Domain.Services.ClubServices.DeviceSetService;

public class DeviceSetService : IDeviceSetService
{
    private readonly AppDbContext _context;

    public DeviceSetService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<DeviceSet?> GetDeviceSetForFreePlaces(string name)
    {
        return await _context.DeviceSets
            .Where(x => x.Name == name)
            .FirstOrDefaultAsync();
    }
}