using System.ComponentModel.DataAnnotations;

namespace ComputerClub.DAL.Models.UserModels;

public class Login
{
    [Required] public string UserName { get; set; }

    [Required] public string Password { get; set; }
}