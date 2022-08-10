namespace Computer_club.WebAPI.Endpoints.FrontendAction.ScheduleAction.Create;

public class CreateScheduleForFrontCommand
{
    public string StartOfWork { get; set; } = new TimeOnly().ToString();
    public string EndOfWork { get; set; } = new TimeOnly().ToString();
    
    public int GameClubId { get; set; }
}