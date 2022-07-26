using Computer_club.Data.Data;
using Computer_club.Data.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Services.UserServices.UserRepository;

public class UserRepository : IUserRepository<User>
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllAsync(CancellationToken token)
    {
        return await _context.Users.ToListAsync(token);
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