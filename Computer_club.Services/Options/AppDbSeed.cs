using Computer_club.Data.Database;
using Computer_club.Data.Entities.ClubEntities;
using Computer_club.Data.Entities.UserEntities;
using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.User;
using Microsoft.AspNetCore.Identity;

namespace Computer_club.Services.Options;

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

    public static async Task SeedAsync
        (UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager, AppDbContext context)
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

        var gameClub = new GameClub
        {
            Id = 1,
            Address = "Ставрополь",
            Description = "Игровой компьютерный клуб",
            IsOwned = true,
            ContractNumber = "12345",
            DigitizedDocument = "54321"
        };
        
        var aroundTheClock = new Schedule
        {
            Id = 1,
            StartOfWork = new TimeOnly(00, 00, 00).ToString(),
            EndOfWork = new TimeOnly(23, 59, 59).ToString(),
            GameClubId = 1
        };
        var twelveToFour = new Schedule
        {
            Id = 2,
            StartOfWork = new TimeOnly(12, 00, 00).ToString(),
            EndOfWork = new TimeOnly(4, 00, 00).ToString(),
            GameClubId = 1
        };
        
        if (userManager.Users.All(x => x.Id != defaultUser.Id))
        {
            await userManager.CreateAsync(defaultUser, SuperAdminPassword);
            await userManager.AddToRoleAsync(defaultUser, SuperAdminRoles);
            await context.GameClubs.AddAsync(gameClub);
            await context.Schedules.AddAsync(aroundTheClock);
            await context.Schedules.AddAsync(twelveToFour);
        }
    }
}