namespace ComputerClub.WebAPI.Endpoints.ClubAction.ScheduleAction.Update;

public class UpdateScheduleRequest
{
    public int Id { get; set; }
    public string Day { get; set; }
    public string Type { get; set; }
    
    public int GameClubId { get; set; }
}