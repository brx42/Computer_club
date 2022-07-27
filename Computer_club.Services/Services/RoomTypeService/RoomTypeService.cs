using Computer_club.Data.Data;
using Computer_club.Data.Models.Club;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Services.Services.RoomTypeService;

public class RoomTypeService : IRoomTypeService<RoomType>
{
    private readonly AppDbContext _context;

    public RoomTypeService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<RoomType>> GetAllAsync(CancellationToken token)
    {
        return await _context.RoomTypes.ToListAsync(token);
    }

    public async Task<RoomType?> GetByIdAsync(Guid id, CancellationToken token)
    {
        return await _context.RoomTypes.FindAsync(id, token);
    }

    public async Task<RoomType>? AddAsync(RoomType room, CancellationToken token)
    {
        await _context.RoomTypes.AddAsync(room, token);
        await _context.SaveChangesAsync(token);
        return room;
    }

    public async Task UpdateAsync(RoomType room)
    {
        _context.RoomTypes.Update(room);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(RoomType room)
    {
        _context.RoomTypes.Remove(room);
        await _context.SaveChangesAsync();
    }
}