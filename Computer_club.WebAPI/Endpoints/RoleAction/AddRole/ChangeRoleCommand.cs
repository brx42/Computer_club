namespace Computer_club.WebAPI.Endpoints.RoleAction.AddRole;

public class AddRoleCommand
{
    public Guid UserId { get; set; }
    public string Role { get; set; }
}