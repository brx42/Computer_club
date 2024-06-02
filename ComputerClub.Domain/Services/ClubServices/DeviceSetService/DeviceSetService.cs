using ComputerClub.DAL.Database;
using ComputerClub.DAL.Models.ClubModels;
using Microsoft.EntityFrameworkCore;

namespace ComputerClub.Domain.Services.ClubServices.DeviceSetService;

public class DeviceSetService : IDeviceSetService
{
    private readonly ApplicationDbContext _context;

    public DeviceSetService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<DeviceSet?> GetDeviceSetForFreePlaces(string name)
    {
        return await _context.DeviceSet
            .Where(x => x.Name == name)
            .FirstOrDefaultAsync();
    }
}