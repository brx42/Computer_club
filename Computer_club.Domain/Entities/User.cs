﻿using Computer_club.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Computer_club.Domain.Entities;

public sealed class User : IdentityUser<Guid>
{
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public string? LastName { get; set; }
    public string? ContactDetails { get; set; }
    public DateTime? DateOfBirth { get; set; }
}