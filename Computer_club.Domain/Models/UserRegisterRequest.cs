using System.ComponentModel.DataAnnotations;

namespace Computer_club.Domain.Models;

public class UserRegisterRequest
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Login { get; set; }
}