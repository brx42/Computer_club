using System.ComponentModel.DataAnnotations;

namespace Computer_club.Domain.Models;

public class AddRole
{
    [Required]
    public string Login { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Role { get; set; }
}