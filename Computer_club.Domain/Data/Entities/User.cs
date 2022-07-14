using System.ComponentModel.DataAnnotations;

namespace Computer_club.Domain.Data.Entities;

public abstract class BaseUser
{
    [Key]
    public Guid Id { get; set; }
}

public class User : BaseUser
{
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public string? LastName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string? ContactDetails { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? DateOfBirth { get; set; } = new DateTime().Date.ToString("d");
    
    public List<UserRole> Roles { get; set; }
    public bool IsActive { get; set; }
}