namespace Computer_club.WebAPI.Endpoints.ClubAction.ScheduleAction.Update;

public class UpdateScheduleResult
{
    public TimeOnly StartOfWork { get; set; }
    public TimeOnly EndOfWork { get; set; }
    
    public int GameClubId { get; set; }
}