using Computer_club.Data.Entities.ClubEntities;

namespace Computer_club.Data.Models.ClubModels;

public class Equipment : BaseClub
{
    public string DeviceName { get; set; }
    public string? DevicePicturePath { get; set; }

    public int PlaceTypeId { get; set; }
    public PlaceType PlaceType { get; set; }
}