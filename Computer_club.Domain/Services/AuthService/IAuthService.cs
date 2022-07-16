using Computer_club.Domain.DTO;
using Computer_club.Domain.Models;

namespace Computer_club.Domain.Services.AuthService;

public interface IAuthService
{
    public Task<ResponseLogin> Login(LoginDTO loginDto);
    public Task<ResponseRegistration> Registration(RegistrationDTO registrationDto);
    public Task<ResponseLogin> RefreshToken(string token);
    public Task Logout(string refreshToken);
}