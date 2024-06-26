﻿using System.ComponentModel.DataAnnotations;

namespace ComputerClub.DAL.Entities;

public class RefreshToken
{
    [Key]
    public string Token { get; set; }
    public DateTime ExpiresAt { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } 
}