using System.ComponentModel.DataAnnotations;

namespace ComputerClub.WebAPI.Endpoints.UserAction.Create;

public class CreateUserResponse : CreateUserRequest
{
    [Key]
    public Guid Id { get; set; }
}