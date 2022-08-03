namespace Computer_club.WebAPI.Endpoints.ClubAction.ScheduleAction.GetById;

public class GetByIdScheduleResult
{
    public int Id { get; set; }
    public string StartOfWork { get; set; }
    public string EndOfWork { get; set; }
    
    public int GameClubId { get; set; }
}