using System.Text;
using System.Text.RegularExpressions;
using Computer_club.Domain.Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Computer_club.Domain.Security;

public class AuthRoles : AuthorizeAttribute
{
    public AuthRoles(params RoleEnum[] roles)
    {
        var str = new StringBuilder();

        foreach (var role in roles)
            str.Append(Enum.GetName(typeof(Role), role) + ",");
        Roles = Regex.Replace(str.ToString(), ",$", "");
    }
}