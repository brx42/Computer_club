using Microsoft.AspNetCore.Identity;

namespace ComputerClub.Domain.Services.UserServices.RoleService;

public interface IRoleService
{
    Task<List<IdentityRole<Guid>>> GetAllAsync(CancellationToken token);
    Task<IdentityResult> AddUserRoleAsync(Guid id, string role);
    Task<IdentityResult> AddManagerAsync(Guid id);
}