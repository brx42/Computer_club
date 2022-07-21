using Computer_club.Domain.Data;
using Computer_club.Domain.DTO;
using Computer_club.Domain.Entities;
using Computer_club.Domain.Models;
using Computer_club.Domain.Services.TokenService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Domain.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly ITokenGenerator _tokenGenerator;
    private readonly AppDbContext _context;
    private readonly UserManager<User> _userManager;

    public AuthService(ITokenGenerator tokenGenerator, AppDbContext context, UserManager<User> userManager)
    {
        _tokenGenerator = tokenGenerator;
        _context = context;
        _userManager = userManager;
    }

    public async Task<Response<Token>> Login(LoginDTO loginDto)
    {
        var response = new Response<Token>();
        try
        {
            var user = await _userManager.FindByNameAsync(loginDto.Login);
            if (user == null)
            {
                response.Message = "Неверный логин";
                return response;
            }

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!result)
            {
                response.Message = "Неверный пароль";
                return response;
            }

            var token = await _tokenGenerator.CreateJwtToken(user);
            var list = _context.RefreshTokens.Where(r => r.UserId == user.Id).ToList();
            if (list.Any())
                _context.RefreshTokens.RemoveRange(list);
            var refreshToken = new RefreshToken
            {
                User = user,
                UserId = user.Id,
                ExpiresAt = DateTime.UtcNow + TimeSpan.FromDays(30),
                Token = _tokenGenerator.CreateRefreshToken()
            };
            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();

            response.Success = true;
            response.Message = "Success";
            response.Data = new Token
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
            response.Message = "Error";
            response.Success = false;
            return response;
        }
    }

    public async Task<Response<IEnumerable<IdentityError>>> Registration(RegistrationDTO registrationDto)
    {
        var response = new Response<IEnumerable<IdentityError>>
        {
            Success = false
        };
        try
        {
            var user = new User
            {
                Email = registrationDto.Email,
                UserName = registrationDto.Login, 
                DateOfBirth = registrationDto.DateOfBirth,
                PhoneNumber = registrationDto.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, registrationDto.Password);
            if (!result.Succeeded)
            {
                response.Data = result.Errors;
                return response;
            }

            response.Message = "Success";
            response.Success = true;
            return response;
        }
        catch (Exception ex)
        {
            
            response.Message = "Error";
            response.Success = false;
            return response;
        }
    }

    public async Task<Response<Token>> RefreshToken(string token)
    {
        var response = new Response<Token>
        {
            Success = false
        };

        try
        {
            var oldToken = _context.RefreshTokens.FirstOrDefault(x => x.Token == token);
            if (oldToken == null)
                return response;

            var user = _context.Users.FirstOrDefault(x => x.Id == oldToken.UserId);
            if (oldToken != null && oldToken.ExpiresAt < DateTime.UtcNow)
            {
                _context.RefreshTokens.Remove(oldToken);
                await _context.SaveChangesAsync();
                return response;
            }

            var newToken = new RefreshToken
            {
                Token = _tokenGenerator.CreateRefreshToken(),
                UserId = user.Id,
                User = user,
                ExpiresAt = DateTime.UtcNow.AddDays(30)
            };

            await _context.RefreshTokens.AddAsync(newToken);
            if (oldToken != null) _context.RefreshTokens.Remove(oldToken);
            await _context.SaveChangesAsync();

            response.Success = true;
            response.Message = "Success";
            response.Data = new Token
            {
                RefreshToken = newToken.Token,
                JwtToken = await _tokenGenerator.CreateJwtToken(user),
                UserId = user.Id,
                Username = user.UserName
            };
            return response;
        }
        catch (Exception ex)
        {
            response.Message = "Error";
            response.Success = true;
            return response;
        }
    }

    public async Task Logout()
    {
        var token = await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token != null);
        _context.RefreshTokens.Remove(token);
        await _context.SaveChangesAsync();
    }
}