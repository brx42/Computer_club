namespace Computer_club.WebAPI.Endpoints.RoleAction.GetById;

public class GetByIdRoleResult
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string NormalizedName { get; set; }
    public string ConcurrencyStamp { get; set; }
}   
