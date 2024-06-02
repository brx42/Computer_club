using ComputerClub.DAL.Entities;

namespace ComputerClub.Domain.Services.UserServices.TokenService;

public interface ITokenGenerator
{
    public Task<string> CreateJwtToken(User user);
    public string CreateRefreshToken();
}