namespace Computer_club.WebAPI.Endpoints.FrontendAction.ScheduleAction.Update;

public class UpdateScheduleForFrontCommand
{
    public int Id { get; set; }
    public string StartOfWork { get; set; } = new TimeOnly().ToString();
    public string EndOfWork { get; set; } = new TimeOnly().ToString();
    
    public int GameClubId { get; set; }
}