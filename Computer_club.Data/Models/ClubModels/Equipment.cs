using Computer_club.Data.Entities.ClubEntities;

namespace Computer_club.Data.Models.ClubModels;

public class Equipment : BaseClub
{
    public string DeviceType { get; set; }
    public string DeviceName { get; set; }
    public string? DevicePicturePath { get; set; }

    public int DeviceSetId { get; set; }
    public DeviceSet DeviceSet { get; set; }
}