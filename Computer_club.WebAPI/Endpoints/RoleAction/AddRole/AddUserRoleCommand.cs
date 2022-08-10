namespace Computer_club.WebAPI.Endpoints.RoleAction.AddRole;

public class AddUserRoleCommand
{
    public Guid UserId { get; set; }
    public string Role { get; set; }
}