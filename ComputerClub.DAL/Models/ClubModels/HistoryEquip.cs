using ComputerClub.DAL.Entities;

namespace ComputerClub.DAL.Models.ClubModels;

public class HistoryEquip : BaseEntity
{
    public DateTime DateOfWork { get; set; }
    public string TypeOfWork { get; set; }
    public string DeviceName { get; set; }
    public int? PriceOfWork { get; set; }
    public string ReasonForWork { get; set; }
    
    public int GameClubId { get; set; }
    public GameEntity GameEntity { get; set; }
}