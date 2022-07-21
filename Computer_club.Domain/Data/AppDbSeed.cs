using Computer_club.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Computer_club.Domain.Data;

public class AppDbSeed 
{
    public static async Task SeedAsync(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
    {
        await roleManager.CreateAsync(new IdentityRole<Guid>(Authorization.Roles.SuperAdmin.ToString()));
        await roleManager.CreateAsync(new IdentityRole<Guid>(Authorization.Roles.Manager.ToString()));
        await roleManager.CreateAsync(new IdentityRole<Guid>(Authorization.Roles.Support.ToString()));
        await roleManager.CreateAsync(new IdentityRole<Guid>(Authorization.Roles.Client.ToString()));
        await roleManager.CreateAsync(new IdentityRole<Guid>(Authorization.Roles.ClubAdmin.ToString()));
        await roleManager.CreateAsync(new IdentityRole<Guid>(Authorization.Roles.SiteAdmin.ToString()));
        await roleManager.CreateAsync(new IdentityRole<Guid>(Authorization.Roles.Analyst.ToString()));
        await roleManager.CreateAsync(new IdentityRole<Guid>(Authorization.Roles.Auditor.ToString()));

        var defaultUser = new User
        {
            UserName = Authorization.SuperAdminUsername,
            Email = Authorization.SuperAdminEmail,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };

        if (userManager.Users.All(x => x.Id != defaultUser.Id))
        {
            await userManager.CreateAsync(defaultUser, Authorization.SuperAdminPassword);
            await userManager.AddToRoleAsync(defaultUser, Authorization.SuperAdminRoles.ToString());
        }
    }
}
