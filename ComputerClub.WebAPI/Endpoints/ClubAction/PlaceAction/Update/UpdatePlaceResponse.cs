namespace ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.Update;

public class UpdatePlaceResponse
{
    public bool IsVip { get; set; }
    public bool IsFree { get; set; }

    public int DeviceSetId { get; set; }
    public int GameClubId { get; set; }
}