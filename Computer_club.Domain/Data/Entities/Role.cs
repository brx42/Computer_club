using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Computer_club.Domain.Security;

namespace Computer_club.Domain.Data.Entities;

[Table("Role")]
public class Role
{
    [Key]
    public int Id { get; set; }
    public RoleEnum Name { get; set; }  
}
public enum RoleEnum
{
    SuperAdministrator,
    Manager,
    Support,
    ClubClient,
    ClubAdministrator,
    SiteAdministrator,
    BusinessAnalyst,
    Auditor
}