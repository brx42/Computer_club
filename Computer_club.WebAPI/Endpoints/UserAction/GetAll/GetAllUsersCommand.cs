namespace Computer_club.WebAPI.Endpoints.UserAction.GetAll;

public class GetAllUsersCommand
{
    public int Page { get; set; }
    public int Limit { get; set; }
}