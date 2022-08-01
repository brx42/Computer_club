using Computer_club.Data.Models.User;
using Computer_club.Data.Models.UserModels;

namespace Computer_club.Services.Services.UserServices.AuthService;

public interface IAuthService
{
    public Task<Response<Token>?> Login(LoginDTO loginDto);
    public Task Registration(RegistrationDTO registrationDto);
    public Task<Response<Token>?> RefreshToken(string token);
    public Task Logout();
}