using Microsoft.AspNetCore.Identity;

namespace Computer_club.Domain.Entities;

public class AppUser : IdentityUser
{
    public string FullName { get; set; }
    public string BirthdayDate { get; set; } = new DateTime().Date.ToString("d");
    public string RegistrationDate { get; set; } = new DateTime().Date.ToString("d");
}