using Microsoft.AspNetCore.Identity;

namespace Computer_club.Services.Services.UserServices.RoleService;

public interface IRoleService
{
    Task<List<IdentityRole<Guid>>> GetAllAsync(CancellationToken token);
    Task AddUserRoleAsync(Guid id, string role);
}