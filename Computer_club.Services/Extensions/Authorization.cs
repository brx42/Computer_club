using Computer_club.Data.Models.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace Computer_club.Services.Extensions;

public static class Authorization
{
    public static IServiceCollection AddRoleAndPolicy(this IServiceCollection service)
    {
        service.AddAuthorization(config =>
        {
            config.AddPolicy(Role.SuperAdmin, opt =>
            {
                opt.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                opt.RequireRole(Role.SuperAdmin);
            });
            
            config.AddPolicy(Role.Manager, opt =>
            {
                opt.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                opt.RequireRole(Role.Manager);
            });
            
            config.AddPolicy(Role.Support, opt =>
            {
                opt.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                opt.RequireRole(Role.Support);
            });
            
            config.AddPolicy(Role.Client, opt =>
            {
                opt.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                opt.RequireRole(Role.Client);
            });
            config.AddPolicy(Role.ClubAdmin, opt =>
            {
                opt.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                opt.RequireRole(Role.ClubAdmin);
            });
            config.AddPolicy(Role.SiteAdmin, opt =>
            {
                opt.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                opt.RequireRole(Role.SiteAdmin);
            });
            config.AddPolicy(Role.Analyst, opt =>
            {
                opt.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                opt.RequireRole(Role.Analyst);
            });
            config.AddPolicy(Role.Auditor, opt =>
            {
                opt.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                opt.RequireRole(Role.Auditor);
            });
        });
        return service;
    }
}