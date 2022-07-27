using System.ComponentModel.DataAnnotations;

namespace Computer_club.Data.Models.User;

public class RegistrationDTO
{
    [Required]
    public string Login { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string? FirstName { get; set; }

    [Required]
    public string? SecondName { get; set; }

    [Required]
    public string? LastName { get; set; }

    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    public string? ContactDetails { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }
}