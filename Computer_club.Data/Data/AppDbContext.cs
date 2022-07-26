using Computer_club.Data.Entities.Club;
using Computer_club.Data.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Data.Data;

public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public AppDbContext(DbContextOptions options) : base(options)

    {
        // Database.EnsureDeleted();
        // Database.EnsureCreated();
    }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Club> Clubs { get; set; }
}