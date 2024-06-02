namespace ComputerClub.WebAPI.Endpoints.RoleAction.AddRole;

public class AddUserRoleRequest
{
    public Guid UserId { get; set; }
    public string Role { get; set; }
}