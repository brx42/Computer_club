using System.ComponentModel.DataAnnotations;

namespace Computer_club.Domain.Models;

public class Register
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Login { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}