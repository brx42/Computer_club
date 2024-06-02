using ComputerClub.DAL.Database;
using ComputerClub.DAL.Entities;
using ComputerClub.DAL.Models.UserModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ComputerClub.Domain.Services.UserServices.RoleService;

public class RoleService : IRoleService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;

    public RoleService(ApplicationDbContext context, UserManager<User> userManager)
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
        User? find = await _userManager.FindByIdAsync(id.ToString());
        IdentityResult result = await _userManager.AddToRoleAsync(find, role);
        return result;
    }

    public async Task<IdentityResult> AddManagerAsync(Guid id)
    {
        User? find = await _userManager.FindByIdAsync(id.ToString());
        IdentityResult result = await _userManager.AddToRoleAsync(find, Role.Manager);
        return result;
    }
}