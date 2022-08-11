namespace Computer_club.WebAPI.Endpoints.BackendAction.ClubAction.PlaceAction.GetById;

public class GetByIdPlaceResult
{
    public int Id { get; set; }
    public bool IsVip { get; set; }
    public bool IsFree { get; set; }

    public int DeviceSetId { get; set; }
    public int GameClubId { get; set; }
}