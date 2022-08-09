using AutoMapper;
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
    private readonly IMapper _mapper;

    public RoleService(AppDbContext context, UserManager<User> userManager, IMapper mapper)
    {
        _context = context;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<List<IdentityRole<Guid>>> GetAllAsync(CancellationToken token)
    {
        return await _context.Roles.ToListAsync(token);
    }

    public async Task ChangeUserRoleAsync(Guid id, string role)
    {
        var find = await _userManager.FindByIdAsync(id.ToString());
        await _userManager.AddToRoleAsync(find, role);
    }
}