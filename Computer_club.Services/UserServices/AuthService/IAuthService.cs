using Computer_club.Data.DTO.Auth;
using Computer_club.Data.Models.User;

namespace Computer_club.Services.UserServices.AuthService;

public interface IAuthService
{
    public Task<Response<Token>?> Login(LoginDTO loginDto);
    public Task Registration(RegistrationDTO registrationDto);
    public Task<Response<Token>?> RefreshToken(string token);
    public Task Logout();
}