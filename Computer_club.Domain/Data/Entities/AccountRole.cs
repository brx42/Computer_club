using System.ComponentModel.DataAnnotations;
using Computer_club.Domain.Data.Entities.User;
using Computer_club.Domain.Models;

namespace Computer_club.Domain.Data.Entities;

public class AccountRole
{
    [Key]
    public Guid Id { get; set; }
    public Account Account { get; set; }
    public RoleModel Role { get; set; }
}