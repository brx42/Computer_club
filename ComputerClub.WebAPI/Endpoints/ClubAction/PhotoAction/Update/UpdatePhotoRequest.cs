namespace ComputerClub.WebAPI.Endpoints.ClubAction.PhotoAction.Update;

public class UpdatePhotoRequest
{
    public int Id { get; set; }
    public string FilePath { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public int GameClubId { get; set; }
}