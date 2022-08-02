namespace Computer_club.WebAPI.Endpoints.ClubAction.PlaceAction.Create;

public class CreatePlaceCommand
{
    public bool IsVip { get; set; }
    public string Status { get; set; }

    public int DeviceSetId { get; set; }
    public int GameClubId { get; set; }
}