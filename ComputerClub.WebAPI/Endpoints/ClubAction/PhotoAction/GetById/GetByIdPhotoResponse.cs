namespace ComputerClub.WebAPI.Endpoints.ClubAction.PhotoAction.GetById;

public class GetByIdPhotoResponse
{
    public int Id { get; set; }
    public string FilePath { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public int GameClubId { get; set; }
}