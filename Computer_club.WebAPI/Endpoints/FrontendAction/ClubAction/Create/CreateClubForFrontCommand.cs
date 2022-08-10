namespace Computer_club.WebAPI.Endpoints.FrontendAction.ClubAction.Create;

public class CreateClubForFrontCommand
{
    public string? Address { get; set; }
    public string? Description { get; set; }
    public bool IsOwned { get; set; }
    public string? ContractNumber { get; set; }
    public string? DigitizedDocument { get; set; }
}