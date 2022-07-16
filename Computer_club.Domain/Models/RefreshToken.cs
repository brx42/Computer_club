using System.ComponentModel.DataAnnotations;
using Computer_club.Domain.Entities;

namespace Computer_club.Domain.Models;

public class RefreshToken
{
    [Key]
    public string Token { get; set; }
    public DateTime ExpiresAt { get; set; }
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
}