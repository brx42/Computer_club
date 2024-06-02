namespace ComputerClub.WebAPI.Endpoints.ClubAction.ScheduleAction.Create;

public class CreateScheduleRequest
{
    public string Day { get; set; }
    public string Type { get; set; }
    
    public int GameClubId { get; set; }
}