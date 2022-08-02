namespace Computer_club.WebAPI.Endpoints.ClubAction.PhotoAction.Update;

public class UpdatePhotoResult
{
    public string FilePath { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public int GameClubId { get; set; }
}