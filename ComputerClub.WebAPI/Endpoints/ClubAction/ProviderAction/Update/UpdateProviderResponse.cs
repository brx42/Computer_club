namespace ComputerClub.WebAPI.Endpoints.ClubAction.ProviderAction.Update;

public class UpdateProviderResponse
{
    public string Name { get; set; }
    public string Speed { get; set; }
    public string Price { get; set; }
    public bool IsStaticIP { get; set; }
    public string? ContractNumber { get; set; }
    public int GameClubId { get; set; }
}