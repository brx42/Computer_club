using Computer_club.Data.Entities;

namespace Computer_club.Domain.Services.UserServices.TokenService;

public interface ITokenGenerator
{
    public Task<string> CreateJwtToken(User user);
    public string CreateRefreshToken();
}