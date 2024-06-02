namespace ComputerClub.WebAPI.Endpoints.ClubAction.ScheduleAction.Create;

public class CreateScheduleResponse
{
    public int Id { get; set; }
    public string Day { get; set; }
    public string Type { get; set; }
    
    public int GameClubId { get; set; }
}