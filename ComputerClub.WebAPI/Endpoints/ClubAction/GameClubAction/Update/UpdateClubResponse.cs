namespace ComputerClub.WebAPI.Endpoints.ClubAction.GameClubAction.Update;

public class UpdateClubResponse
{
    
    public string? Address { get; set; }
    public string? Description { get; set; }
    public bool IsOwned { get; set; }
    public string? ContractNumber { get; set; }
    public string? DigitizedDocument { get; set; }
}