namespace Computer_club.WebAPI.Endpoints.BackendAction.ClubAction.ScheduleAction.GetAll;

public class GetAllScheduleResult
{
    public int Id { get; set; }
    public string StartOfWork { get; set; } = new TimeOnly().ToString();
    public string EndOfWork { get; set; } = new TimeOnly().ToString();
    
    public int GameClubId { get; set; }
}