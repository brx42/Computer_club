using System.ComponentModel.DataAnnotations;

namespace Computer_club.Data.Models.UserModels;

public class LoginDTO
{
    [Required]
    public string Login{ get; set; }

    [Required]
    public string Password{ get; set; }
}