using Computer_club.Data.Entities.User;
using Computer_club.Data.Models.User;
using Microsoft.AspNetCore.Identity;

namespace Computer_club.Data.Data;

public class AppDbSeed 
{
    public const string SuperAdminUserName = "SuperAdmin";
    public const string SuperAdminEmail = "SuperAdmin@localhost.ru";
    public const string SuperAdminPassword = "SuperAdmin123.";
    public const string SuperAdminFirstName = "SuperAdminFirstName";
    public const string SuperAdminSecondName = "SuperAdminSecondName";
    public const string SuperAdminLastName = "SuperAdminLastName";
    public const string SuperAdminContactDetails = "SuperAdminContactDetails";
    public static DateTime SuperAdminDateOfBirth;
    public const string SuperAdminPhoneNumber = "SuperAdminPhoneNumber";
    public const string SuperAdminRoles = Role.SuperAdmin;

    public static async Task SeedAsync(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
    {
        await roleManager.CreateAsync(new IdentityRole<Guid>(Role.SuperAdmin));
        await roleManager.CreateAsync(new IdentityRole<Guid>(Role.Manager));
        await roleManager.CreateAsync(new IdentityRole<Guid>(Role.Support));
        await roleManager.CreateAsync(new IdentityRole<Guid>(Role.Client));
        await roleManager.CreateAsync(new IdentityRole<Guid>(Role.ClubAdmin));
        await roleManager.CreateAsync(new IdentityRole<Guid>(Role.SiteAdmin));
        await roleManager.CreateAsync(new IdentityRole<Guid>(Role.Analyst));
        await roleManager.CreateAsync(new IdentityRole<Guid>(Role.Auditor));

        var defaultUser = new User
        {
            UserName = SuperAdminUserName,
            Email = SuperAdminEmail,
            FirstName = SuperAdminFirstName,
            SecondName = SuperAdminSecondName,
            LastName = SuperAdminLastName,
            PhoneNumber = SuperAdminPhoneNumber,
            DateOfBirth = SuperAdminDateOfBirth,
            ContactDetails = SuperAdminContactDetails,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };

        if (userManager.Users.All(x => x.Id != defaultUser.Id))
        {
            await userManager.CreateAsync(defaultUser, SuperAdminPassword);
            await userManager.AddToRoleAsync(defaultUser, SuperAdminRoles);
        }
    }
}