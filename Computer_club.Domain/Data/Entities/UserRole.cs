using System.ComponentModel.DataAnnotations;
using Computer_club.Domain.Models;

namespace Computer_club.Domain.Data.Entities;

public class UserRole
{
    [Key]
    public Guid Id { get; set; }
    public User User { get; set; }
    public Role Role { get; set; }
}