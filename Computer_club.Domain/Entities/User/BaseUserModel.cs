using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Computer_club.Domain.Entities.User;

public abstract class BaseUserModel : IdentityUser
{
    [Key]
    public Guid Id { get; set; }
}