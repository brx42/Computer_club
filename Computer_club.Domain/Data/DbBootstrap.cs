/*
using Computer_club.Domain.Data.Entities;
using Computer_club.Domain.Security;
using Computer_club.Domain.Services.AccountService;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Computer_club.Domain.Data;

public static class DbBootstrap
{
    public static void Init(AppDbContext _context, AccountService _service)
    {
        foreach (var role in Enum.GetNames(typeof(Role)))
            _context.Roles.Add(new Role { Name = Enum.Parse<RoleEnum>(role) });
        _context.SaveChanges();

        var superAdmin = _service.Register
            ("SuperAdmin", "SAdmin@localhost", "123456");
        _service.AddRole(superAdmin, RoleEnum.SuperAdministrator);
        _service.Register("user", "user@localhost", "123456");
    }
}
*/