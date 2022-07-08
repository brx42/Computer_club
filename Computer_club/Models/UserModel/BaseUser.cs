using System.ComponentModel.DataAnnotations;

namespace Computer_club.Models.UserModel;

public abstract class BaseUser
{
    [Key]
    public Guid Id { get; set; }
}