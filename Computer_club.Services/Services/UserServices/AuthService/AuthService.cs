using AutoMapper;
using Computer_club.Data.Database;
using Computer_club.Data.Entities.UserEntities;
using Computer_club.Data.Models.User;
using Computer_club.Services.Services.UserServices.TokenService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Services.Services.UserServices.AuthService;

public class AuthService : IAuthService
{
    private readonly ITokenGenerator _tokenGenerator;
    private readonly AppDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public AuthService(ITokenGenerator tokenGenerator, AppDbContext context, UserManager<User> userManager, IMapper mapper)
    {
        _tokenGenerator = tokenGenerator;
        _context = context;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<Response<Token>?> Login(LoginDTO loginDto)
    {
        var response = new Response<Token>();
        var user = await _userManager.FindByNameAsync(loginDto.Login);
        if (user == null)
        {
            return null;    
        }

        var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
        if (!result)
        {
            throw new Exception();
        }

        var token = await _tokenGenerator.CreateJwtToken(user);
        var refreshToken = new RefreshToken
        {
            User = user,
            UserId = user.Id,
            ExpiresAt = DateTime.UtcNow + TimeSpan.FromDays(30),
            Token = _tokenGenerator.CreateRefreshToken()
        };
        await _context.RefreshTokens.AddAsync(refreshToken);
        await _context.SaveChangesAsync();
        var userRole =(await _userManager.GetRolesAsync(user)).FirstOrDefault();

        response.Data = new Token
        {
            RefreshToken = refreshToken.Token,
            JwtToken = token,
            UserId = user.Id,
            Username = user.UserName,
            Role = userRole
        };
        return response;
    }

    public async Task Registration(RegistrationDTO registrationDto)
    {
        var user = new User();
        _mapper.Map(registrationDto, user);

        var result = await _userManager.CreateAsync(user, registrationDto.Password);
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.FirstOrDefault()?.Description);
        }

        
        await _userManager.AddToRoleAsync(user, Role.Client);
    }

    public async Task<Response<Token>?> RefreshToken(string token)
    {
        var response = new Response<Token>();
        var oldToken = _context.RefreshTokens.FirstOrDefault(x => x.Token == token);
        if (oldToken == null)
            return null;

        var user = _context.Users.FirstOrDefault(x => x.Id == oldToken.UserId);
        if (oldToken is not null && oldToken.ExpiresAt < DateTime.UtcNow)
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
        response.Data = new Token
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
        var token = await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token != null);
        _context.RefreshTokens.Remove(token);
        await _context.SaveChangesAsync();
    }
}