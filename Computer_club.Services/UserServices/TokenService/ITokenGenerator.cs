using Computer_club.Data.Entities.User;

namespace Computer_club.Services.UserServices.TokenService;

public interface ITokenGenerator
{
    public Task<string> CreateJwtToken(User user);
    public string CreateRefreshToken();
}