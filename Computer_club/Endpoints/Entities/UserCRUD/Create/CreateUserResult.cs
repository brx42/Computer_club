using System.ComponentModel.DataAnnotations;

namespace Computer_club.Endpoints.Entities.UserCRUD.Create;

public class CreateUserResult : CreateUserCommand
{
    [Key]
    public Guid Id { get; set; }
}