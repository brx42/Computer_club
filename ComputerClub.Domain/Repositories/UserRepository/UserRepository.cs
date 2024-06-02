using ComputerClub.DAL.Database;
using ComputerClub.DAL.Entities;
using ComputerClub.Domain.Options;
using Microsoft.EntityFrameworkCore;

namespace ComputerClub.Domain.Repositories.UserRepository;

public class UserRepository : IUserRepository<User>
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllAsync(Pagination pagination, CancellationToken token)
    {
        return await _context.Users
                .Skip(pagination.Skip)
                .Take(pagination.Take)
                .ToListAsync(token);
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

    public async Task<User> UpdateAsync(User user, CancellationToken token)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync(token);
        return user;
    }

    public async Task<User> DeleteAsync(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return user;
    }
}