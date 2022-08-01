using System.ComponentModel.DataAnnotations;

namespace Computer_club.Data.Entities.ClubEntities;

public abstract class BaseClub
{
    [Key] public int Id { get; }
}