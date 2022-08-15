using Microsoft.AspNetCore.Identity;

namespace Computer_club.Domain.Services.UserServices.RoleService;

public interface IRoleService
{
    Task<List<IdentityRole<Guid>>> GetAllAsync(CancellationToken token);
    Task<IdentityResult> AddUserRoleAsync(Guid id, string role);
    Task<IdentityResult> AddManagerAsync(Guid id);
}