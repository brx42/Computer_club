﻿using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;

namespace Computer_club.Domain.Security;

public class AuthRoles : AuthorizeAttribute
{
    public AuthRoles(params Role[] roles)
    {
        var str = new StringBuilder();

        foreach (var role in roles)
            str.Append(Enum.GetName(typeof(Role), role) + ",");
        Roles = Regex.Replace(str.ToString(), ",$", "");
    }
}