using Computer_club.Data.Database;
using Computer_club.Data.Entities.UserEntities;
using Computer_club.Data.Models.UserModels;
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

    public async Task<IdentityResult> AddUserRoleAsync(Guid id, string role)
    {
        var find = await _userManager.FindByIdAsync(id.ToString());
        var result = await _userManager.AddToRoleAsync(find, role);
        return result;
    }

    public async Task<IdentityResult> AddManagerAsync(Guid id)
    {
        var find = await _userManager.FindByIdAsync(id.ToString());
        var result = await _userManager.AddToRoleAsync(find, Role.Manager);
        return result;
    }
}