namespace ComputerClub.WebAPI.Endpoints.ClubAction.PhotoAction.Create;

public class CreatePhotoResponse
{
    public int Id { get; set; }
    public string FilePath { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public int GameClubId { get; set; }
}