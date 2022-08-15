using Computer_club.Data.Database;
using Computer_club.Data.Entities.ClubEntities;
using Computer_club.Data.Entities.UserEntities;
using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Microsoft.AspNetCore.Identity;

namespace Computer_club.Domain.Options;

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
        GameClub club = new GameClub
        {
            Id = 1,
            Address = "Ставрополь",
            Description = "Компьютерный игровой клуб",
            IsOwned = true,
            ContractNumber = "12345",
            DigitizedDocument = "54321"
        };

        List<Schedule> schedule = new List<Schedule>
        {
            new Schedule { Id = 1, Day = "Monday", Type = "12:00 - 04:00", GameClubId = 1},
            new Schedule { Id = 2, Day = "Tuesday", Type = "12:00 - 04:00", GameClubId = 1},
            new Schedule { Id = 3, Day = "Wednesday", Type = "12:00 - 04:00", GameClubId = 1},
            new Schedule { Id = 4, Day = "Thursday", Type = "12:00 - 04:00", GameClubId = 1},
            new Schedule { Id = 5, Day = "Friday", Type = "Around the clock", GameClubId = 1},
            new Schedule { Id = 6, Day = "Saturday", Type = "Around the clock", GameClubId = 1},
            new Schedule { Id = 7, Day = "Sunday", Type = "Around the clock", GameClubId = 1},
        };
         await context.GameClubs.AddAsync(club);
         await context.Schedules.AddRangeAsync(schedule);
         await context.SaveChangesAsync();
         

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
        
        await userManager.CreateAsync(defaultUser, SuperAdminPassword);
        await userManager.AddToRoleAsync(defaultUser, SuperAdminRoles);
    }
}