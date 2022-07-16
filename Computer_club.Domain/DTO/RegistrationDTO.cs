using System.ComponentModel.DataAnnotations;

namespace Computer_club.Domain.DTO;

public class RegistrationDTO
{
    [Required]
    public string FullName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string BirthdayDate { get; set; } = new DateTime().Date.ToString("d");
    [Required]
    public string RegistrationDate { get; set; }  = new DateTime().Date.ToString("d");
    [Required]
    public string PhoneNumber { get; set; }
}