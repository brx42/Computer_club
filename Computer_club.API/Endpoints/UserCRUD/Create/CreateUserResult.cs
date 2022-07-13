using System.ComponentModel.DataAnnotations;

namespace Computer_club.Endpoints.UserCRUD.Create;

public class CreateUserResult : CreateUserCommand
{
    [Key]
    public Guid Id { get; set; }
}