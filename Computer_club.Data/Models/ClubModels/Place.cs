using Computer_club.Data.Entities.ClubEntities;

namespace Computer_club.Data.Models.ClubModels;

public class Place : BaseClub
{
    public bool IsVip { get; set; }
    public string Status { get; set; }

    public int PlaceTypeId { get; set; }
    public PlaceType PlaceType { get; set; }

    public int GameClubId { get; set; }
    public GameClub GameClub { get; set; }
}