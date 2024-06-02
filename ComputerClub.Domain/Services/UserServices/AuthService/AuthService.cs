using ComputerClub.DAL.Database;
using ComputerClub.DAL.Entities;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Services.UserServices.TokenService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ComputerClub.Domain.Services.UserServices.AuthService;

public class AuthService : IAuthService
{
    private readonly ITokenGenerator _tokenGenerator;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;

    private const string UserNotFound = "UserNotFound";
    private const string WrongPassword = "WrongPassword";

    public AuthService(ITokenGenerator tokenGenerator, ApplicationDbContext context, UserManager<User> userManager)
    {
        _tokenGenerator = tokenGenerator;
        _context = context;
        _userManager = userManager;
    }

    public async Task<Token?> Login(Login login)
    {
        Token response = new();

        User? user = await _userManager.FindByNameAsync(login.UserName);
        if (user == null)
        {
            response.Description = UserNotFound;
            return response;
        }

        bool result = await _userManager.CheckPasswordAsync(user, login.Password);
        if (!result)
        {
            response.Description = WrongPassword;
            return response;
        }

        string token = await _tokenGenerator.CreateJwtToken(user);
        RefreshToken refreshToken = new()
        {
            User = user,
            UserId = user.Id,
            ExpiresAt = DateTime.UtcNow + TimeSpan.FromDays(30),
            Token = _tokenGenerator.CreateRefreshToken()
        };
        await _context.RefreshToken.AddAsync(refreshToken);
        await _context.SaveChangesAsync();
        string? userRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

        response = new Token
        {
            RefreshToken = refreshToken.Token,
            JwtToken = token,
            UserId = user.Id,
            Username = user.UserName,
            Role = userRole!
        };

        return response;
    }

    public async Task<bool> Registration(User user)
    {
        IdentityResult addedUser = await _userManager.CreateAsync(user, user.PasswordHash);
        if (!addedUser.Succeeded)
        {
            return addedUser.Succeeded;
        }

        IdentityResult response = await _userManager.AddToRoleAsync(user, Role.Client);
        return response.Succeeded;
    }

    public async Task<Token?> RefreshToken(string token)
    {
        RefreshToken? oldToken = _context.RefreshToken.FirstOrDefault(x => x.Token == token);
        if (oldToken == null)
        {
            return null;
        }

        User? user = _context.Users.FirstOrDefault(x => x.Id == oldToken.UserId);

        if (oldToken is not null && oldToken.ExpiresAt < DateTime.UtcNow)
        {
            _context.RefreshToken.Remove(oldToken);
            await _context.SaveChangesAsync();
            return null;
        }

        RefreshToken newToken = new()
        {
            Token = _tokenGenerator.CreateRefreshToken(),
            UserId = user.Id,
            User = user,
            ExpiresAt = DateTime.UtcNow.AddDays(30)
        };

        await _context.RefreshToken.AddAsync(newToken);

        if (oldToken != null)
        {
            _context.RefreshToken.Remove(oldToken);
        }

        await _context.SaveChangesAsync();

        Token response = new()
        {
            RefreshToken = newToken.Token,
            JwtToken = await _tokenGenerator.CreateJwtToken(user),
            UserId = user.Id,
            Username = user.UserName,
        };

        return response;
    }

    public async Task Logout()
    {
        RefreshToken? token = await _context.RefreshToken.FirstOrDefaultAsync(x => x.Token != null);
        _context.RefreshToken.Remove(token);
        await _context.SaveChangesAsync();
    }
}