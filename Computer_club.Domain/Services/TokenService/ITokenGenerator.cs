using Computer_club.Domain.Entities;

namespace Computer_club.Domain.Services.TokenService;

public interface ITokenGenerator
{
    public Task<string> CreateJwtToken(User user);
    public string CreateRefreshToken();
}