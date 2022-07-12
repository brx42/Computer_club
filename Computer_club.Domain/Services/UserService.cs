using Computer_club.Domain.DataContext;
using Computer_club.Domain.Default;
using Computer_club.Domain.Models;
using Computer_club.Domain.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Computer_club.Domain.Entities.User;

namespace Computer_club.Domain.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;
    private readonly UserManager<UserModel> _userManager;
    private readonly JwtSettings _jwt;
    
    public UserService(AppDbContext context, UserManager<UserModel> userManager, RoleManager<IdentityRole> roleManager, JwtSettings jwt)
    {
        _context = context;
        _userManager = userManager;
        _jwt = jwt;
    }

    public async Task<string> RegisterAsync(Register register)
    {
        var user = new UserModel
        {
            Login = register.Login,
            Email = register.Email,
            FirstName = register.FirstName,
            LastName = register.LastName
        };
        var userWithSameEmail = await _userManager.FindByLoginAsync(register.Login, _jwt.Key);
        if (userWithSameEmail == null)
        {
            var result = await _userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Authorization.Default_Role.ToString());
            }

            return $"Пользователь с логином - {user.UserName} зарегистрирован.";
        }
        else return $"Email {user.Email} уже зарегистрирован.";
    }
    

    public async Task<Authentication> GetTokenAsync(TokenRequestModel model)
    {
        var authenticationModel = new Authentication();
        var user = await _userManager.FindByLoginAsync(model.Login, _jwt.Key);
        if (user == null)
        {
            authenticationModel.IsAuthenticated = false;
            authenticationModel.Message = $"Аккаунт не зарегистрирован - {model.Login}";
            return authenticationModel;
        }

        if (await _userManager.CheckPasswordAsync(user, model.Password))
        {
            authenticationModel.IsAuthenticated = true;
            JwtSecurityToken jwtSecurityToken = await CreateJwtToken(user);
            authenticationModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authenticationModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authenticationModel.Email = user.Email;
            authenticationModel.Login = user.UserName;
            var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            authenticationModel.Roles = rolesList.ToList();

            if (user.RefreshTokens.Any(a => a.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens.FirstOrDefault(a => a.IsActive == true);
                authenticationModel.RefreshToken = activeRefreshToken.Token;
                authenticationModel.RefreshTokenExpiration = activeRefreshToken.Expires;
            }
            else
            {
                var refreshToken = CreateRefreshToken();
                authenticationModel.RefreshToken = refreshToken.Token;
                authenticationModel.RefreshTokenExpiration = refreshToken.Expires;
                user.RefreshTokens.Add(refreshToken);
                _context.Update(user);
                await _context.SaveChangesAsync();    
            }

            return authenticationModel;
        }

        authenticationModel.IsAuthenticated = false;
        authenticationModel.Message = $"Неверные данные пользователя {user.Email}";
        return authenticationModel;
    }

    public async Task<string> AddRoleAsync(AddRole role)
    {
        var user = await _userManager.FindByLoginAsync(role.Login, _jwt.Key);
        if (user == null)
        {
            return $"Аккаунт - {role.Login} не зарегистрирован.";
        }

        if (await _userManager.CheckPasswordAsync(user, role.Password))
        {
            var roleExists = Enum.GetNames(typeof(Roles)).
                Any(x => x.ToLower() == role.Role.ToLower());
            if (roleExists)
            {
                var validRole = Enum.GetValues(typeof(Roles))
                    .Cast<Roles>().FirstOrDefault(x => x.ToString().ToLower() == role.Role.ToLower());
                await _userManager.AddToRoleAsync(user, validRole.ToString());
                return $"Добавлен {role.Role} к пользователю {role.Login}";
            }

            return $"Роль {role.Role} не найдена";
        }

        return $"Неправильные данные пользователя {user.Email}";
    }

    public async Task<Authentication> RefreshTokenAsync(string jwtToken)
    {
        var authentication = new Authentication();
        var user = await _context.Users.SingleOrDefaultAsync
            (x => x.RefreshTokens.Any(t => t.Token == jwtToken));
        if (user == null)
        {
            authentication.IsAuthenticated = false;
            authentication.Message = $"Токен не соответствует ни одному пользователю.";
            return authentication;
        }

        var refreshToken = user.RefreshTokens.Single(x => x.Token == jwtToken);

        if (!refreshToken.IsActive)
        {
            authentication.IsAuthenticated = false;
            authentication.Message = "Токен не активен";
            return authentication;
        }
        refreshToken.Revoked = DateTime.UtcNow;

        var newRefreshToken = CreateRefreshToken();
        user.RefreshTokens.Add(newRefreshToken);
        _context.Update(user);
        await _context.SaveChangesAsync();

        authentication.IsAuthenticated = true;
        JwtSecurityToken jwtSecurityToken = await CreateJwtToken(user);
        authentication.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        authentication.Email = user.Email;
        authentication.Login = user.UserName;
        var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
        authentication.Roles = rolesList.ToList();
        authentication.RefreshToken = newRefreshToken.Token;
        authentication.RefreshTokenExpiration = newRefreshToken.Expires;
        return authentication;

    }

    public bool RevokeToken(string token)
    {
        var user = _context.Users.SingleOrDefault(x => x.RefreshTokens.
                                                Any(t => t.Token == token));

        if (user == null) return false;

        var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

        if (!refreshToken.IsActive) return false;
        
        refreshToken.Revoked = DateTime.UtcNow;
        _context.Update(user);
        _context.SaveChanges();
        return true;
    }




    #region JwtSettings
    private RefreshToken CreateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var generator = new RNGCryptoServiceProvider())
        {
            generator.GetBytes(randomNumber);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow
            };

        }
    }
    
    
    private async Task<JwtSecurityToken> CreateJwtToken(UserModel user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        var roleClaims = new List<Claim>();

        for (int i = 0; i < roles.Count; i++)
        {
            roleClaims.Add(new Claim("roles", roles[i]));
        }

        var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id.ToString())
            }
            .Union(userClaims)
            .Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
            signingCredentials: signingCredentials);
        return jwtSecurityToken;
    }
    #endregion
}
