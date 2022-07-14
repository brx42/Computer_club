using Computer_club.Domain.Data.Entities;
using Computer_club.Domain.Security;

namespace Computer_club.Domain.Services.AccountService;

public interface IAccountService
{
    User Register(string nickname, string email, string password);

    string Login(string login, string password);

    void AddRole(User user, RoleEnum role);
}