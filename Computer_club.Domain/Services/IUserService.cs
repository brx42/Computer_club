using Computer_club.Domain.Models;

namespace Computer_club.Domain.Services;

public interface IUserService
{
    Task<string> RegisterAsync(Register register);
    Task<Authentication> GetTokenAsync(TokenRequestModel model);
    Task<string> AddRoleAsync(AddRole role);
    Task<Authentication> RefreshTokenAsync(string jwtToken);
    bool RevokeToken(string token);
}