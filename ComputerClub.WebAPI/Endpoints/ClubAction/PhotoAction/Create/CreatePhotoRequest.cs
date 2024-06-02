namespace ComputerClub.WebAPI.Endpoints.ClubAction.PhotoAction.Create;

public class CreatePhotoRequest
{
    public string FilePath { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public int GameClubId { get; set; }
}