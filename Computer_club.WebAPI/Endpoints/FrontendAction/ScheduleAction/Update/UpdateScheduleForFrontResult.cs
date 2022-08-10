namespace Computer_club.WebAPI.Endpoints.FrontendAction.ScheduleAction.Update;

public class UpdateScheduleForFrontResult
{
    public TimeOnly StartOfWork { get; set; }
    public TimeOnly EndOfWork { get; set; }
    
    public int GameClubId { get; set; }
}