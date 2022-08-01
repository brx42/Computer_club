using Computer_club.Data.Database;
using Computer_club.Data.Entities.UserEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Services.Services.UserServices.RoleService;

public class RoleService : IRoleService<IdentityRole<Guid>>
{
    private readonly AppDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;

    public RoleService(AppDbContext context, UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<List<IdentityRole<Guid>>?> GetAllAsync(CancellationToken token)
    {
        return await _context.Roles.ToListAsync(token);
    }

    public async Task<IdentityRole<Guid>?> GetRoleByIdAsync(Guid id)
    {
        return await _context.Roles.FindAsync(id);
    }

    public async Task<IdentityResult> CreateRoleAsync(string role)
    {
        var result = await _roleManager.CreateAsync(new IdentityRole<Guid> { Name = role });
        return result;
    }

    public async Task<IdentityResult> DeleteRoleAsync(IdentityRole<Guid> role)
    {
        var result = await _roleManager.DeleteAsync(role);
        return result;
    }
}