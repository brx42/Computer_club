namespace Computer_club.WebAPI.Endpoints.ClubAction.PlaceAction.GetAllBusy;

public class GetAllBusyPlacesResult
{
    public int Id { get; set; }
    public bool IsVip { get; set; }
    public bool IsFree { get; set; }

    public int DeviceSetId { get; set; }
    public int GameClubId { get; set; }
}