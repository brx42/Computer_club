namespace Computer_club.WebAPI.Endpoints.ClubAction.ScheduleAction.Create;

public class CreateScheduleResult
{
    public int Id { get; set; }
    public TimeOnly StartOfWork { get; set; }
    public TimeOnly EndOfWork { get; set; }
    
    public int GameClubId { get; set; }
}