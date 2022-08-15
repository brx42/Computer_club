using Computer_club.Data.Entities.ClubEntities;

namespace Computer_club.Data.Models.ClubModels;

public class Schedule : BaseClub
{
    public string Day { get; set; }
    public string Type { get; set; }
        
    public int GameClubId { get; set; }
    public GameClub GameClub { get; set; }
}