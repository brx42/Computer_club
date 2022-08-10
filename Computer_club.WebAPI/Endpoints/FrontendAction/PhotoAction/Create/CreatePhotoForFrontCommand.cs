namespace Computer_club.WebAPI.Endpoints.FrontendAction.PhotoAction.Create;

public class CreatePhotoForFrontCommand
{
    public string FilePath { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public int GameClubId { get; set; }
}