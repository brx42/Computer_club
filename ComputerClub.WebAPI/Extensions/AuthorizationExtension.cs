using System.Security.Claims;
using ComputerClub.DAL.Models.UserModels;

namespace ComputerClub.WebAPI.Extensions;

public static class AuthorizationExtension
{
    public static IServiceCollection AddRoleAndPolicy(this IServiceCollection service)
    {
        service.AddAuthorizationBuilder()
            .AddPolicy(Role.SuperAdmin, opt =>
            {
                opt.AuthenticationSchemes.Add("Bearer");
                opt.RequireAuthenticatedUser();
                opt.RequireRole(Role.SuperAdmin);
                opt.RequireClaim(ClaimTypes.Role, Role.SuperAdmin);
                opt.RequireUserName("SuperAdmin");
            })
            .AddPolicy(Role.Manager, opt =>
            {
                opt.AuthenticationSchemes.Add("Bearer");
                opt.RequireAuthenticatedUser();
                opt.RequireRole(Role.Manager, Role.SuperAdmin);
                opt.RequireClaim(ClaimTypes.Role, Role.Manager);
            })
            .AddPolicy(Role.Support, opt =>
            {
                opt.AuthenticationSchemes.Add("Bearer");
                opt.RequireAuthenticatedUser();
                opt.RequireRole(Role.Support, Role.SuperAdmin);
                opt.RequireClaim(ClaimTypes.Role, Role.Support);
            })
            .AddPolicy(Role.Client, opt =>
            {
                opt.AuthenticationSchemes.Add("Bearer");
                opt.RequireAuthenticatedUser();
                opt.RequireRole(Role.Client, Role.SuperAdmin, Role.ClubAdmin, Role.Manager);
                opt.RequireClaim(ClaimTypes.Role, Role.Client);
            })
            .AddPolicy(Role.ClubAdmin, opt =>
            {
                opt.AuthenticationSchemes.Add("Bearer");
                opt.RequireAuthenticatedUser();
                opt.RequireRole(Role.ClubAdmin, Role.SuperAdmin);
                opt.RequireClaim(ClaimTypes.Role, Role.ClubAdmin);
            })
            .AddPolicy(Role.SiteAdmin, opt =>
            {
                opt.AuthenticationSchemes.Add("Bearer");
                opt.RequireAuthenticatedUser();
                opt.RequireRole(Role.SiteAdmin, Role.SuperAdmin);
                opt.RequireClaim(ClaimTypes.Role, Role.SiteAdmin);
            })
            .AddPolicy(Role.Analyst, opt =>
            {
                opt.AuthenticationSchemes.Add("Bearer");
                opt.RequireAuthenticatedUser();
                opt.RequireRole(Role.Analyst, Role.SuperAdmin);
                opt.RequireClaim(ClaimTypes.Role, Role.Analyst);
            })
            .AddPolicy(Role.Auditor, opt =>
            {
                opt.AuthenticationSchemes.Add("Bearer");
                opt.RequireAuthenticatedUser();
                opt.RequireRole(Role.Auditor, Role.SuperAdmin);
                opt.RequireClaim(ClaimTypes.Role, Role.Auditor);
            });
        return service;
    }
}