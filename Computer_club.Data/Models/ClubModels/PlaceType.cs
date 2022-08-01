using Computer_club.Data.Entities.ClubEntities;

namespace Computer_club.Data.Models.ClubModels;

public class PlaceType : BaseClub
{
    public string Name { get; set; }

    public List<Equipment> Equipments { get; set; }
    public Place Place { get; set; }
}