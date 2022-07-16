using Computer_club.Domain.Data;
using Computer_club.Domain.DTO;
using Computer_club.Domain.Entities;
using Computer_club.Domain.Models;
using Computer_club.Domain.Services.TokenService;
using Microsoft.AspNetCore.Identity;

namespace Computer_club.Domain.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly ITokenGenerator _tokenGenerator;
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _userManager;

    public AuthService(ITokenGenerator tokenGenerator, AppDbContext context, UserManager<AppUser> userManager)
    {
        _tokenGenerator = tokenGenerator;
        _context = context;
        _userManager = userManager;
    }

    public async Task<ResponseLogin> Login(LoginDTO loginDto)
    {
        var response = new ResponseLogin { Success = false };
        try
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Login);
            if (user == null)
            {
                response.Message = "Неверный логин или пароль";
                return response;
            }

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!result)
            {
                response.Message = "Неверный логин или пароль";
                return response;
            }

            var token = _tokenGenerator.CreateJwtToken(user);
            var list = _context.RefreshTokens.Where(r => r.AppUserId == user.Id).ToList();
            if (list.Count() > 0)
                _context.RefreshTokens.RemoveRange(list);
            var refreshToken = new RefreshToken
            {
                AppUser = user,
                AppUserId = user.Id,
                ExpiresAt = DateTime.UtcNow + TimeSpan.FromDays(30),
                Token = _tokenGenerator.CreateRefreshToken()
            };
            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();

            response.Success = true;
            response.Message = ResponseMessage.Success.ToString();
            response.Token = new Token
            {
                RefreshToken = refreshToken.Token,
                JwtToken = token,
                UserId = user.Id,
                Username = user.UserName
            };
            return response;
        }
        catch (Exception ex)
        {
            response.Message = ResponseMessage.Error.ToString();
            response.Success = false;
            return response;
        }
    }

    public async Task<ResponseRegistration> Registration(RegistrationDTO registrationDto)
    {
        var response = new ResponseRegistration
        {
            Success = false,
            Message = ResponseMessage.Error.ToString()
        };
        try
        {
            var user = new AppUser
            {
                FullName = registrationDto.FullName,
                Email = registrationDto.Email,
                UserName = registrationDto.Email,
                RegistrationDate = DateTime.UtcNow.ToString(),
                BirthdayDate = registrationDto.BirthdayDate,
                PhoneNumber = registrationDto.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, registrationDto.Password);
            if (!result.Succeeded)
            {
                response.Errors = result.Errors;
                return response;
            }

            response.Message = ResponseMessage.Success.ToString();
            response.Success = true;
            return response;
        }
        catch (Exception ex)
        {
            response.Message = ResponseMessage.Error.ToString();
            response.Success = false;
            return response;
        }
    }

    public async Task<ResponseLogin> RefreshToken(string token)
    {
        ResponseLogin response = new ResponseLogin
        {
            Message = ResponseMessage.Error.ToString(),
            Success = false
        };

        try
        {
            var refreshToken = _context.RefreshTokens.FirstOrDefault(x => x.Token == token);
            if (refreshToken == null)
                return response;

            var user = _context.Users.FirstOrDefault(x => x.Id == refreshToken.AppUserId);
            if (refreshToken != null && refreshToken.ExpiresAt < DateTime.UtcNow)
            {
                _context.RefreshTokens.Remove(refreshToken);
                await _context.SaveChangesAsync();
                return response;
            }

            var newToken = new RefreshToken
            {
                Token = _tokenGenerator.CreateRefreshToken(),
                AppUserId = user.Id,
                AppUser = user as AppUser,
                ExpiresAt = DateTime.UtcNow.AddDays(30)
            };

            await _context.RefreshTokens.AddAsync(newToken);
            _context.RefreshTokens.Remove(refreshToken);
            await _context.SaveChangesAsync();

            response.Success = true;
            response.Message = ResponseMessage.Success.ToString();
            response.Token = new Token
            {
                RefreshToken = newToken.Token,
                JwtToken = _tokenGenerator.CreateJwtToken((AppUser)user),
                UserId = user.Id,
                Username = user.UserName
            };
            return response;
        }
        catch (Exception ex)
        {
            response.Message = ResponseMessage.Error.ToString();
            response.Success = false;
            return response;
        }
    }

    public async Task Logout(string refreshToken)
    {
        var token = _context.RefreshTokens.FirstOrDefault(x => x.Token == refreshToken);
        _context.RefreshTokens.Remove(token);
        await _context.SaveChangesAsync();
    }
}