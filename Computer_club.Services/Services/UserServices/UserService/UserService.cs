using Computer_club.Data.Database;
using Computer_club.Data.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Services.Services.UserServices.UserService;

public class UserService : IUserService<User>
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllAsync(int perPage, int page, CancellationToken token)
    {
        return await _context.Users.Skip(perPage * (page - 1)).Take(perPage).ToListAsync(token);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> AddAsync(User user, CancellationToken token)
    {
        await _context.Users.AddAsync(user, token);
        await _context.SaveChangesAsync(token);
        return user;
    }

    public async Task UpdateAsync(User user, CancellationToken token)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}