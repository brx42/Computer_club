using ComputerClub.DAL.Entities;
using ComputerClub.DAL.Models.UserModels;

namespace ComputerClub.Domain.Services.UserServices.AuthService;

public interface IAuthService
{
    public Task<Token?> Login(Login login);
    public Task<bool> Registration(User user);
    public Task<Token> RefreshToken(string token);
    public Task Logout();
}