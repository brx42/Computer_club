namespace Computer_club.WebAPI.Endpoints.ClubAction.ScheduleAction.Create;

public class CreateScheduleCommand
{
    public string Day { get; set; }
    public string Type { get; set; }
    
    public int GameClubId { get; set; }
}