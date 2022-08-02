namespace Computer_club.WebAPI.Endpoints.ClubAction.PlaceAction.Update;

public class UpdatePlaceResult
{
    public bool IsVip { get; set; }
    public string Status { get; set; }

    public int DeviceSetId { get; set; }
    public int GameClubId { get; set; }
}