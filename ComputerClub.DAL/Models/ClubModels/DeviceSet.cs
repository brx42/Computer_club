using ComputerClub.DAL.Entities;

namespace ComputerClub.DAL.Models.ClubModels;

public class DeviceSet : BaseEntity 
{
    public string Name { get; set; }

    public List<Equipment> Equipments { get; set; }
    public List<Place> Place { get; set; }
    
    public int GameClubId { get; set; }
    public GameEntity GameEntity { get; set; }
}