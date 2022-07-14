using System.ComponentModel.DataAnnotations;

namespace Computer_club.Domain.Models;

public class UserLoginRequest
{
    [Required] 
    public string Login { get; set; }
    [Required] 
    public string Password { get; set; }
}