namespace Computer_club.WebAPI.Endpoints.ClubAction.DescriptionAction.Update;

public class UpdateDescriptionCommand
{
    public Guid Id { get; set; }
    public string Description { get; set; }
}