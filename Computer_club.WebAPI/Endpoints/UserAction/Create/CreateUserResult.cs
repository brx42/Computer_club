using System.ComponentModel.DataAnnotations;

namespace Computer_club.WebAPI.Endpoints.UserAction.Create;

public class CreateUserResult : CreateUserCommand
{
    [Key]
    public Guid Id { get; set; }
}