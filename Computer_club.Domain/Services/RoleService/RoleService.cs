using Computer_club.Domain.Data;
using Computer_club.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Domain.Services.RoleService;

public class RoleService : IRoleService<Role>
{
    private readonly RoleManager<Role> _roleManager;
    private readonly AppDbContext _context;

    public RoleService(RoleManager<Role> roleManager, AppDbContext context)
    {
        _roleManager = roleManager;
        _context = context;
    }


    public async Task<Role?> GetRoleByIdAsync(Guid Id)
    {
        return await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == Id);
    }
}