namespace ComputerClub.WebAPI.Endpoints.ClubAction.ScheduleAction.GetById;

public class GetByIdScheduleResponse
{
    public int Id { get; set; }
    public string Day { get; set; }
    public string Type { get; set; }
    
    public int GameClubId { get; set; }
}