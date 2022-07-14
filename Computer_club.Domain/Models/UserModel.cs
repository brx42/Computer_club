using Computer_club.Domain.Data.Entities;
using Computer_club.Domain.Security;

namespace Computer_club.Domain.Models;

public class UserModel
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }
    public IEnumerable<string> Roles { get; set; }

    public static UserModel From(User user)
    {
        return new UserModel()
        {
            Id = user.Id,
            Email = user.Email,
            Login = user.Login,
            Roles = user.Roles.Select(r => Enum.GetName(typeof(Role), r.Role.Name))
        };
    }
}