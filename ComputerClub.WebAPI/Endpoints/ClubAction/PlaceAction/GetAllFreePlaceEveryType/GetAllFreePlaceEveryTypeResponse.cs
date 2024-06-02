namespace ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.GetAllFreePlaceEveryType;

public class GetAllFreePlaceEveryTypeResponse
{
    public string DeviceSet { get; set; }

    public List<PlaceNotReal> Places { get; set; }
}

public class PlaceNotReal
{
    public int Id { get; set; }
    public bool IsVip { get; set; }
    public bool IsFree { get; set; }

    public int DeviceSetId { get; set; }
    public int GameClubId { get; set; }
}