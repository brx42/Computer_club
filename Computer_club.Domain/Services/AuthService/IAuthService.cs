using Computer_club.Domain.DTO;
using Computer_club.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Computer_club.Domain.Services.AuthService;

public interface IAuthService
{
    public Task<Response<Token>?> Login(LoginDTO loginDto);
    public Task Registration(RegistrationDTO registrationDto);
    public Task<Response<Token>?> RefreshToken(string token);
    public Task Logout();
}