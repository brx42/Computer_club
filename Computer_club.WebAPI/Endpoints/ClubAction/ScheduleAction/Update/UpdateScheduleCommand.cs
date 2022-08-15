namespace Computer_club.WebAPI.Endpoints.ClubAction.ScheduleAction.Update;

public class UpdateScheduleCommand
{
    public int Id { get; set; }
    public string StartOfWork { get; set; } = new TimeOnly().ToString();
    public string EndOfWork { get; set; } = new TimeOnly().ToString();
    
    public int GameClubId { get; set; }
}