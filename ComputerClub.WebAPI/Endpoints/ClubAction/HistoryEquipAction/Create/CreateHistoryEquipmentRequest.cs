namespace ComputerClub.WebAPI.Endpoints.ClubAction.HistoryEquipAction.Create;

public class CreateHistoryEquipmentRequest
{
    public DateTime DateOfWork { get; set; }
    public string TypeOfWork { get; set; }
    public string DeviceName { get; set; }
    public int? PriceOfWork { get; set; }
    public string ReasonForWork { get; set; }
    
    public int GameClubId { get; set; }
}