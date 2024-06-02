namespace ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.Create;

public class CreatePlaceRequest
{
    public bool IsVip { get; set; }
    public bool IsFree { get; set; }

    public int DeviceSetId { get; set; }
    public int GameClubId { get; set; }
}