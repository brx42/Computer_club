namespace Computer_club.WebAPI.Endpoints.FrontendAction.PlaceAction.Update;

public class UpdatePlaceForFrontCommand
{
    public int Id { get; set; }
    public bool IsVip { get; set; }
    public string Status { get; set; }

    public int DeviceSetId { get; set; }
    public int GameClubId { get; set; }
}