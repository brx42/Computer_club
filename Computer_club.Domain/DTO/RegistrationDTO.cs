using System.ComponentModel.DataAnnotations;

namespace Computer_club.Domain.DTO;

public class RegistrationDTO
{
    [Required]
    public string Login { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public DateTime DateOfBirth { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
}