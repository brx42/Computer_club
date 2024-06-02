namespace ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.Update;

public class UpdatePlaceRequest
{
    public int Id { get; set; }
    public bool IsVip { get; set; }
    public bool IsFree { get; set; }

    public int DeviceSetId { get; set; }
    public int GameClubId { get; set; }
}