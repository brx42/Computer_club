using Computer_club.Domain.Data;
using Computer_club.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Domain.Services.UserService;

public class UserRepository : IUserRepository<User>
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllAsync(CancellationToken token)
    {
        return await _context.UserModels.ToListAsync(token);
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken token)
    {
        return await _context.UserModels.SingleOrDefaultAsync(x =>
            x.Id == id, token);
    }

    public async Task<User> AddAsync(User user, CancellationToken token)
    {
        await _context.UserModels.AddAsync(user, token);
        await _context.SaveChangesAsync(token);
        return user;
    }

    public async Task UpdateAsync(User user, CancellationToken token)
    {
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(User user, CancellationToken token)
    {
        _context.UserModels.Remove(user);
        await _context.SaveChangesAsync(token);
    }
}