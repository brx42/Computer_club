namespace Computer_club.WebAPI.Endpoints.BackendAction.ClubAction.ProviderAction.GetById;

public class GetByIdProviderResult
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Speed { get; set; }
    public string Price { get; set; }
    public bool IsStaticIP { get; set; }
    public string? ContractNumber { get; set; }
    public int GameClubId { get; set; }
}