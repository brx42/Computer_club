namespace ComputerClub.WebAPI.Endpoints.ClubAction.ScheduleAction.GetAll;

public class GetAllScheduleResponse
{
    public int Id { get; set; }
    public string Day { get; set; }
    public string Type { get; set; }
    
    public int GameClubId { get; set; }
}