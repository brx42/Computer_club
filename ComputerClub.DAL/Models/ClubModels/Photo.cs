using ComputerClub.DAL.Entities;

namespace ComputerClub.DAL.Models.ClubModels;

public class Photo : BaseEntity
{
    public string FilePath { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public int GameClubId { get; set; }
    public GameEntity GameEntity { get; set; }
}