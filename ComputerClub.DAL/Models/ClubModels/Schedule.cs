using ComputerClub.DAL.Entities;

namespace ComputerClub.DAL.Models.ClubModels;

public class Schedule : BaseEntity
{
    public string Day { get; set; }
    public string Type { get; set; }
        
    public int GameClubId { get; set; }
    public GameEntity GameEntity { get; set; }
}