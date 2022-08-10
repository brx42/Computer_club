using Computer_club.Data.Database;
using Computer_club.Data.Entities.UserEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Services.Services.UserServices.RoleService;

public class RoleService : IRoleService
{
    private readonly AppDbContext _context;
    private readonly UserManager<User> _userManager;

    public RoleService(AppDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<List<IdentityRole<Guid>>> GetAllAsync(CancellationToken token)
    {
        return await _context.Roles.ToListAsync(token);
    }

    public async Task AddUserRoleAsync(Guid id, string role)
    {
        var find = await _userManager.FindByIdAsync(id.ToString());
        await _userManager.AddToRoleAsync(find, role);
    }
}