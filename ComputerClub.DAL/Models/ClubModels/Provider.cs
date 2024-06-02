using ComputerClub.DAL.Entities;

namespace ComputerClub.DAL.Models.ClubModels;

public class Provider : BaseEntity
{
    public string Name { get; set; }
    public string Speed { get; set; }
    public string Price { get; set; }
    public bool IsStaticIP { get; set; }
    public string? ContractNumber { get; set; }

    public int GameClubId { get; set; }
    public GameEntity GameEntity { get; set; }
}