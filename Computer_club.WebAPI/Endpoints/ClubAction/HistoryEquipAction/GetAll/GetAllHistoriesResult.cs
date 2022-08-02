namespace Computer_club.WebAPI.Endpoints.ClubAction.HistoryEquipAction.GetAll;

public class GetAllHistoriesResult
{
    public int Id { get; set; }
    public DateTime DateOfWork { get; set; }
    public string TypeOfWork { get; set; }
    public string DeviceName { get; set; }
    public int? PriceOfWork { get; set; }
    public string ReasonForWork { get; set; }
    
    public int GameClubId { get; set; }
}