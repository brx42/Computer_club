using ComputerClub.DAL.Entities;

namespace ComputerClub.DAL.Models.ClubModels;

public class Place : BaseEntity
{
    public bool IsVip { get; set; }
    public bool IsFree { get; set; }

    public int DeviceSetId { get; set; }
    public DeviceSet DeviceSet { get; set; }

    public int GameClubId { get; set; }
    public GameEntity GameEntity { get; set; }
}