using System.ComponentModel.DataAnnotations;

namespace Computer_club.Data.DTO.Auth;

public class LoginDTO
{
    [Required]
    public string Login{ get; set; }

    [Required]
    public string Password{ get; set; }
}