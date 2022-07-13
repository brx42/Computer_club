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

    public Account Register(string nickname, string email, string password)
    {
        if (_context.Accounts.Any(p => p.Email == email))
            throw new ServiceException("Электронная почта уже зарегистрирована.");
        if (_context.Accounts.Any(p => p.NickName == nickname))
            throw new ServiceException("Никнейм уже зарегистрирован.");

        var account = new Account()
        {
            CreationDate = DateTime.UtcNow,
            Active = true,
            NickName = nickname,
            Email = email,
            Password = Encryptor.Md5Hash(password),
            Roles = new List<AccountRole>()
        };
        
        AddRole(account, Role.ClubClient);
        _context.Accounts.Add(account);
        _context.SaveChanges();
        return account;
    }

    public string Login(string login, string password)
    {
        var account = _context.Accounts
            .Include(a => a.Roles)
            .Include("Roles.Role")
            .FirstOrDefault(a => (a.NickName == login || a.Email == login) &&
                                 a.Password == Encryptor.Md5Hash(password));

        if (account == null)
            throw new ServiceException("Пользователь не существует.");
        if (!account.Active)
            throw new ServiceException("Неверный аккаунт.");

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, account.NickName),
            new Claim(JwtRegisteredClaimNames.Jti, account.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, account.Email)
        };

        foreach (var role in account.Roles)
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

    public void AddRole(Account account, Role role)
    {
        var roleToAdd = _context.Roles.FirstOrDefault(r => r.Name == role);

        if (roleToAdd == null)
            throw new ServiceException("Роли не существует.");
        if (account.Roles.Any(r => r.Role.Name == role))
            throw new ServiceException("Учётная запись уже зарегистрирована для этой роли.");
        
        account.Roles.Add(new AccountRole {Account = account, Role = roleToAdd});
        _context.SaveChanges();
    }
}