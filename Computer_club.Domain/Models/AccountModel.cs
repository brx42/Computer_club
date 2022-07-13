using Computer_club.Domain.Data.Entities;
using Computer_club.Domain.Data.Entities.User;
using Computer_club.Domain.Security;

namespace Computer_club.Domain.Models;

public class AccountModel
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string NickName { get; set; }
    public DateTime CreationDate { get; set; }
    public IEnumerable<string> Roles { get; set; }

    public static AccountModel From(Account account)
    {
        return new AccountModel()
        {
            Id = account.Id,
            CreationDate = account.CreationDate,
            Email = account.Email,
            NickName = account.NickName,
            Roles = account.Roles.Select(r => Enum.GetName(typeof(Role), r.Role.Name))
        };
    }
}