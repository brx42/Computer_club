using Computer_club.Data.Entities.UserEntities;

namespace Computer_club.Services.Services.UserServices.TokenService;

public interface ITokenGenerator
{
    public Task<string> CreateJwtToken(User user);
    public string CreateRefreshToken();
}