using Computer_club.Domain.Default;
using Computer_club.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;

namespace Computer_club.Domain.DataContext;

public class AppDbContextSeed
{
    public static async Task SeedEssentialsAsync(UserManager<UserModel> userManager, RoleManager<IdentityRole> roleManager)
    {
        await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdministrator.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.Manager.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.Support.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.ClubAdministrator.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.SiteAdministrator.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.BusinessAnalyst.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.Auditor.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.ClubClient.ToString()));

        var defaultUser = new UserModel()
        {
            Login = Authorization.Default_Login,
            Email = Authorization.Default_Email,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };
        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            await userManager.CreateAsync(defaultUser, Authorization.Default_Password);
            await userManager.AddToRoleAsync(defaultUser, Authorization.Default_Role.ToString());
        }
    }
}