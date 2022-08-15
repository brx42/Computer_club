namespace Computer_club.WebAPI.Endpoints.ClubAction.ScheduleAction.Create;

public class CreateScheduleCommand
{
    public string StartOfWork { get; set; } = new TimeOnly().ToString();
    public string EndOfWork { get; set; } = new TimeOnly().ToString();
    
    public int GameClubId { get; set; }
}