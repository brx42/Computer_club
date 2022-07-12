using Computer_club.Domain.DataContext;
using Computer_club.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Domain.Services;

public class UserRepository : IUserRepository<UserModel>
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserModel>> GetAllAsync(CancellationToken token)
    {
        return await _context.Users.ToListAsync(token);
    }

    public async Task<UserModel?> GetByIdAsync(Guid id, CancellationToken token)
    {
        return await _context.Users.SingleOrDefaultAsync(x =>
            x.Id == id, token);
    }

    public async Task<UserModel> AddAsync(UserModel user, CancellationToken token)
    {
        await _context.Users.AddAsync(user, token);
        await _context.SaveChangesAsync(token);
        return user;
    }

    public async Task UpdateAsync(UserModel user, CancellationToken token)
    {
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(UserModel user, CancellationToken token)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync(token);
    }
}