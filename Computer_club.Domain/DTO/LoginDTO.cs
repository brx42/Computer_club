using System.ComponentModel.DataAnnotations;

namespace Computer_club.Domain.DTO;

public class LoginDTO
{
    [Required]
    public string Login{ get; set; }

    [Required]
    public string Password{ get; set; }
}