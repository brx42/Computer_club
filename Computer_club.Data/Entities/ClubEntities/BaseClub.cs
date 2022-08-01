using System.ComponentModel.DataAnnotations;

namespace Computer_club.Data.Entities.ClubEntities;

public class BaseClub
{
    [Key] public int Id { get; set; }
}