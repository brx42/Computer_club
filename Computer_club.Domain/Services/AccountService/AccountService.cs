using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Computer_club.Domain.Data;
using Computer_club.Domain.Data.Entities;
using Computer_club.Domain.Exceptions;
using Computer_club.Domain.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Computer_club.Domain.Services.AccountService;

public class AccountService : IAccountService
{
    private readonly IConfiguration _configuration;
    private readonly AppDbContext _context;

    public AccountService(IConfiguration configuration, AppDbContext context)
    {
        _configuration = configuration;
        _context = context;
    }
    

    public User Register(string login, string email, string password)
    {
        if (_context.Users.Any(p => p.Email == email))
            throw new ServiceException("Электронная почта уже зарегистрирована.");
        if (_context.Users.Any(p => p.Login == login))
            throw new ServiceException("Логин уже зарегистрирован.");

        var user = new User
        {
            Login = login,
            Email = email,
            Password = Encryptor.Md5Hash(password),
            Roles = new List<UserRole>()
        };
        
        AddRole(user, RoleEnum.ClubClient);
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public string Login(string login, string password)
    {
        var user = _context.Users
            .Include(a => a.Roles)
            .Include("Roles.Role")
            .FirstOrDefault(a => (a.Login == login || a.Email == login) &&
                                 a.Password == Encryptor.Md5Hash(password));

        if (user == null)
            throw new ServiceException("Пользователь не существует.");
        if (!user.IsActive)
            throw new ServiceException("Неверный аккаунт.");

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Login),
            new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email)
        };

        foreach (var role in user.Roles)
            claims.Add(new Claim("role", Enum.GetName(typeof(Role), role.Role.Name)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtToken:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
        (
            _configuration["JwtToken:Issuer"],
            _configuration["JwtToken:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(10),
            signingCredentials: creds
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public void AddRole(User user, RoleEnum role)
    {
        var roleToAdd = _context.Roles.FirstOrDefault(r => r.Name == role);

        if (roleToAdd == null)
            throw new ServiceException("Роли не существует.");
        if (user.Roles.Any(r => r.Role.Name == role))
            throw new ServiceException("Учётная запись уже зарегистрирована для этой роли.");
        
        user.Roles.Add(new UserRole {User = user, Role = roleToAdd});
        _context.SaveChanges();
    }
}