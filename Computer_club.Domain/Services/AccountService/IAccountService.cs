using Computer_club.Domain.Data.Entities;
using Computer_club.Domain.Security;

namespace Computer_club.Domain.Services.AccountService;

public interface IAccountService
{
    Account Register(string nickname, string email, string password);

    string Login(string login, string password);

    void AddRole(Account account, Role role);
}