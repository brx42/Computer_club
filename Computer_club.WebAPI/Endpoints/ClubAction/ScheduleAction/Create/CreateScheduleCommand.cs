namespace Computer_club.WebAPI.Endpoints.ClubAction.ScheduleAction.Create;

public class CreateScheduleCommand
{
    public string StartOfWork { get; set; }
    public string EndOfWork { get; set; }
    
    public int GameClubId { get; set; }
}