using Computer_club.Data.Database;
using Computer_club.Data.Models.ClubModels;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Services.Services.ClubServices.DeviceSetService;

public class DeviceSetService : IDeviceSetService<DeviceSet>
{
    private readonly AppDbContext _context;

    public DeviceSetService(AppDbContext context)
    {
        _context = context;
    }

    
    public async Task<List<DeviceSet>> GetAllAsync(CancellationToken token)
    {
        return await _context.DeviceSets.ToListAsync(token);
    }

    public async Task<DeviceSet?> GetByIdAsync(int id)
    {
        return await _context.DeviceSets.FindAsync(id);
    }

    public async Task<DeviceSet> AddAsync(DeviceSet set, CancellationToken token)
    {
        await _context.DeviceSets.AddAsync(set, token);
        await _context.SaveChangesAsync(token);
        return set;
    }

    public async Task UpdateAsync(DeviceSet set, CancellationToken token)
    {
        _context.DeviceSets.Update(set);
        await _context.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(DeviceSet set, CancellationToken token)
    {
        _context.DeviceSets.Remove(set);
        await _context.SaveChangesAsync(token);
    }
}