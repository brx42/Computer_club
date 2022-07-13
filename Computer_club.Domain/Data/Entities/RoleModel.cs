using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Computer_club.Domain.Security;

namespace Computer_club.Domain.Data.Entities;

[Table("Role")]
public class RoleModel
{
    [Key]
    public Guid Id { get; set; }
    public Role Name { get; set; }  
}