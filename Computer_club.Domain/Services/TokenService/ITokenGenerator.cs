using Computer_club.Domain.Entities;

namespace Computer_club.Domain.Services.TokenService;

public interface ITokenGenerator
{
    public string CreateJwtToken(AppUser user);
    public string CreateRefreshToken();
}