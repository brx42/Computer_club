using Computer_club.Data.Entities;

namespace Computer_club.Data.Models.ClubModels;

public class Provider : BaseClub
{
    public string Name { get; set; }
    public string Speed { get; set; }
    public string Price { get; set; }
    public bool IsStaticIP { get; set; }
    public string? ContractNumber { get; set; }

    public int GameClubId { get; set; }
    public GameClub GameClub { get; set; }
}