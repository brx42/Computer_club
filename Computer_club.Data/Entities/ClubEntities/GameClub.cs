using Computer_club.Data.Models.ClubModels;

namespace Computer_club.Data.Entities.ClubEntities;

public class GameClub : BaseClub
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
}