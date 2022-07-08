using Computer_club.Models.UserModel;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Data.Repository.UserRepository;

public class UserRepository : IUserRepository<User>
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken token)
    {
        return await _context.Users.ToListAsync(token);
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken token)
    {
        return await _context.Users.SingleOrDefaultAsync(x =>
            x.Id == id, token);
    }

    public async Task<User> AddAsync(User user, CancellationToken token)
    {
        await _context.Users.AddAsync(user, token);
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
        _context.Users.Remove(user);
        await _context.SaveChangesAsync(token);
    }
}