using ComputerClub.DAL.Entities;

namespace ComputerClub.DAL.Models.ClubModels;

public class Equipment : BaseEntity
{
    public string DeviceType { get; set; }
    public string DeviceName { get; set; }
    public string? DevicePicturePath { get; set; }

    public int DeviceSetId { get; set; }
    public DeviceSet DeviceSet { get; set; }
    
    public int GameClubId { get; set; }
    public GameEntity GameEntity { get; set; }
}