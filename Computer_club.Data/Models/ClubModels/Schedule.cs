using Computer_club.Data.Entities.ClubEntities;
using Computer_club.Data.Models.Enums;

namespace Computer_club.Data.Models.ClubModels;

public class Schedule : BaseClub
{
    public ScheduleType TimeCatalog { get; set; }

    public int GameClubId { get; set; }
    public GameClub GameClub { get; set; }
}