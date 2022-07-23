namespace Computer_club.Domain.Services.RoleService;

public interface IRoleService<T>
{
    Task<T?> GetRoleByIdAsync(Guid Id);
    
}