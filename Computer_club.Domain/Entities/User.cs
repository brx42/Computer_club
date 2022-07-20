using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Computer_club.Domain.Entities;

public abstract class BaseUser : IdentityUser
{
    [Key]
    public new Guid Id { get; set; }
}

public class User : BaseUser 
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string LastName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string ContactDetails { get; set; }
    public new string Email { get; set; }
    public new string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
}