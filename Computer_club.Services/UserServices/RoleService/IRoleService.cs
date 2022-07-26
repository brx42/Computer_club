using Microsoft.AspNetCore.Identity;

namespace Computer_club.Services.UserServices.RoleService;

public interface IRoleService<T>
{
    Task<List<T>?> GetAllAsync(CancellationToken token);
    Task<T?> GetRoleByIdAsync(Guid id);
    Task<IdentityResult> CreateRoleAsync(string role);
    Task<IdentityResult> DeleteRoleAsync(T id);
}