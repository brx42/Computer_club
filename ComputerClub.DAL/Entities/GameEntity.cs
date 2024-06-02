using ComputerClub.DAL.Models.ClubModels;

namespace ComputerClub.DAL.Entities;

public class GameEntity : BaseEntity
{
    public string? Address { get; set; }
    public string? Description { get; set; }
    public bool IsOwned { get; set; }
    public string? ContractNumber { get; set; }
    public string? DigitizedDocument { get; set; }


    public Provider Provider { get; set; }
    public List<HistoryEquip> HistoryEquips { get; set; }
    public List<Schedule> Schedules { get; set; }
    public List<Photo> Photos { get; set; }
    public List<Place> Places { get; set; }
    public List<Equipment> Equipments { get; set; }
    public List<DeviceSet> DeviceSets { get; set; }
    public List<User> Users { get; set; }
}