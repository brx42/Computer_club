using System.Security.Claims;
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
                opt.AuthenticationSchemes.Add("Bearer");
                opt.RequireAuthenticatedUser();
                opt.RequireRole(Role.SuperAdmin);
                opt.RequireClaim(ClaimTypes.Role, Role.SuperAdmin);
                opt.RequireUserName("SuperAdmin");
            });
            
            config.AddPolicy(Role.Manager, opt =>
            {
                opt.AuthenticationSchemes.Add("Bearer");
                opt.RequireAuthenticatedUser();
                opt.RequireRole(Role.Manager, Role.SuperAdmin);
                opt.RequireClaim(ClaimTypes.Role, Role.Manager);
            });
            
            config.AddPolicy(Role.Support, opt =>
            {
                opt.AuthenticationSchemes.Add("Bearer");
                opt.RequireAuthenticatedUser();
                opt.RequireRole(Role.Support, Role.SuperAdmin);
                opt.RequireClaim(ClaimTypes.Role, Role.Support);
            });
            
            config.AddPolicy(Role.Client, opt =>
            {
                opt.AuthenticationSchemes.Add("Bearer");
                opt.RequireAuthenticatedUser();
                opt.RequireRole(Role.Client, Role.SuperAdmin, Role.ClubAdmin, Role.Manager);
                opt.RequireClaim(ClaimTypes.Role, Role.Client);
            });
            
            config.AddPolicy(Role.ClubAdmin, opt =>
            {
                opt.AuthenticationSchemes.Add("Bearer");
                opt.RequireAuthenticatedUser();
                opt.RequireRole(Role.ClubAdmin, Role.SuperAdmin);
                opt.RequireClaim(ClaimTypes.Role, Role.ClubAdmin);
            });
            
            config.AddPolicy(Role.SiteAdmin, opt =>
            {
                opt.AuthenticationSchemes.Add("Bearer");
                opt.RequireAuthenticatedUser();
                opt.RequireRole(Role.SiteAdmin, Role.SuperAdmin);
                opt.RequireClaim(ClaimTypes.Role, Role.SiteAdmin);
            });
            
            config.AddPolicy(Role.Analyst, opt =>
            {
                opt.AuthenticationSchemes.Add("Bearer");
                opt.RequireAuthenticatedUser();
                opt.RequireRole(Role.Analyst, Role.SuperAdmin);
                opt.RequireClaim(ClaimTypes.Role, Role.Analyst);
            });
            
            config.AddPolicy(Role.Auditor, opt =>
            {
                opt.AuthenticationSchemes.Add("Bearer");
                opt.RequireAuthenticatedUser();
                opt.RequireRole(Role.Auditor, Role.SuperAdmin);
                opt.RequireClaim(ClaimTypes.Role, Role.Auditor);
            });
            
        });
        return service;
    }
}