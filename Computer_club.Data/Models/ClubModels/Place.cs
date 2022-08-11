using Computer_club.Data.Entities.ClubEntities;

namespace Computer_club.Data.Models.ClubModels;

public class Place : BaseClub
{
    public bool IsVip { get; set; }
    public bool IsFree { get; set; }

    public int DeviceSetId { get; set; }
    public DeviceSet DeviceSet { get; set; }

    public int GameClubId { get; set; }
    public GameClub GameClub { get; set; }
}