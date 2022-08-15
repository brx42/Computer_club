namespace Computer_club.WebAPI.Endpoints.ClubAction.ScheduleAction.GetAll;

public class GetAllScheduleResult
{
    public int Id { get; set; }
    public string Day { get; set; }
    public string Type { get; set; }
    
    public int GameClubId { get; set; }
}