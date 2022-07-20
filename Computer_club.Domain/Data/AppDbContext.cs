using Computer_club.Domain.Entities;
using Computer_club.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Domain.Data;

public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions options) : base(options)

    {
         Database.EnsureDeleted();
         Database.EnsureCreated();
    }
    public DbSet<User>? UserModels { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    
}