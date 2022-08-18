using Computer_club.Data.Entities;
using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Microsoft.AspNetCore.Identity;

namespace Computer_club.Domain.Options;

public class ProjectSeed
{
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    private readonly UserManager<User> _userManager;

    public ProjectSeed(RoleManager<IdentityRole<Guid>> roleManager, UserManager<User> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    private const string SuperAdminUserName = "SuperAdmin";
    private const string SuperAdminEmail = "SuperAdmin@localhost.ru";
    private const string SuperAdminPassword = "SuperAdmin123.";
    private const string SuperAdminFirstName = "SuperAdminFirstName";
    private const string SuperAdminSecondName = "SuperAdminSecondName";
    private const string SuperAdminLastName = "SuperAdminLastName";
    private const string SuperAdminContactDetails = "SuperAdminContactDetails";
    private static DateTime SuperAdminDateOfBirth;
    private const string SuperAdminPhoneNumber = "SuperAdminPhoneNumber";
    private const string SuperAdminRoles = Role.SuperAdmin;

    private readonly GameClub _defaultClub = new()
    {
        Address = "Ставрополь",
        Description = "Компьютерный игровой клуб",
        IsOwned = true,
        ContractNumber = "12345",
        DigitizedDocument = "54321",
        Schedules = new()
        {
            new Schedule { Id = 0, Day = "Monday", Type = "12:00 - 04:00", GameClubId = 1 },
            new Schedule { Id = 0, Day = "Tuesday", Type = "12:00 - 04:00", GameClubId = 1 },
            new Schedule { Id = 0, Day = "Wednesday", Type = "12:00 - 04:00", GameClubId = 1 },
            new Schedule { Id = 0, Day = "Thursday", Type = "12:00 - 04:00", GameClubId = 1 },
            new Schedule { Id = 0, Day = "Friday", Type = "Around the clock", GameClubId = 1 },
            new Schedule { Id = 0, Day = "Saturday", Type = "Around the clock", GameClubId = 1 },
            new Schedule { Id = 0, Day = "Sunday", Type = "Around the clock", GameClubId = 1 }
        }
    };

     private readonly User _defaultUser = new()
    {
        GameClubs = new List<GameClub>(1),
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

    public async Task SeedAsync()
    {
        await _roleManager.CreateAsync(new IdentityRole<Guid>(Role.SuperAdmin));
        await _roleManager.CreateAsync(new IdentityRole<Guid>(Role.Manager));
        await _roleManager.CreateAsync(new IdentityRole<Guid>(Role.Support));
        await _roleManager.CreateAsync(new IdentityRole<Guid>(Role.Client));
        await _roleManager.CreateAsync(new IdentityRole<Guid>(Role.ClubAdmin));
        await _roleManager.CreateAsync(new IdentityRole<Guid>(Role.SiteAdmin));
        await _roleManager.CreateAsync(new IdentityRole<Guid>(Role.Analyst));
        await _roleManager.CreateAsync(new IdentityRole<Guid>(Role.Auditor));

        await _userManager.CreateAsync(_defaultUser, SuperAdminPassword);
        
        _defaultUser.GameClubs = new List<GameClub>(1) { _defaultClub };
        
        _defaultClub.Users = new List<User>(1) { _defaultUser };

        await _userManager.AddToRoleAsync(_defaultUser, SuperAdminRoles);
    }
}