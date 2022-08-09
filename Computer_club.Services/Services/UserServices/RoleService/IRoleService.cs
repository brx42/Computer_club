using Computer_club.Data.Entities.UserEntities;
using Computer_club.Data.Models.UserModels;
using Microsoft.AspNetCore.Identity;

namespace Computer_club.Services.Services.UserServices.RoleService;

public interface IRoleService
{
    Task<List<IdentityRole<Guid>>> GetAllAsync(CancellationToken token);
    Task ChangeUserRoleAsync(Guid id, string role);
}