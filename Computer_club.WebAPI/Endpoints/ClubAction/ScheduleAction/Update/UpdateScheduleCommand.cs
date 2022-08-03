namespace Computer_club.WebAPI.Endpoints.ClubAction.ScheduleAction.Update;

public class UpdateScheduleCommand
{
    public int Id { get; set; }
    public string StartOfWork { get; set; }
    public string EndOfWork { get; set; }
    
    public int GameClubId { get; set; }
}