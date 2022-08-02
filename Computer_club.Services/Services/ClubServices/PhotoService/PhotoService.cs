using Computer_club.Data.Database;
using Computer_club.Data.Models.ClubModels;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Services.Services.ClubServices.PhotoService;

public class PhotoService : IPhotoService<Photo>
{
    private readonly AppDbContext _context;

    public PhotoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Photo>> GetAllAsync(CancellationToken token)
    {
        return await _context.Photos.ToListAsync(token);
    }

    public async Task<Photo?> GetByIdAsync(int id)
    {
        return await _context.Photos.FindAsync(id);
    }

    public async Task<Photo> AddAsync(Photo photo, CancellationToken token)
    {
        await _context.Photos.AddAsync(photo, token);
        await _context.SaveChangesAsync(token);
        return photo;
    }

    public async Task UpdateAsync(Photo photo, CancellationToken token)
    {
        _context.Photos.Update(photo);
        await _context.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(Photo photo, CancellationToken token)
    {
        _context.Photos.Remove(photo);
        await _context.SaveChangesAsync(token);
    }
}