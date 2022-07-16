using Computer_club.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RefreshToken = Computer_club.Domain.Models.RefreshToken;

namespace Computer_club.Domain.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)

    {
         Database.EnsureDeleted();
         Database.EnsureCreated();
     }
    public DbSet<User>? UserModels { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    
}