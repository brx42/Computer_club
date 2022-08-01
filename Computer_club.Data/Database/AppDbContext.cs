using Computer_club.Data.Entities.ClubEntities;
using Computer_club.Data.Entities.UserEntities;
using Computer_club.Data.Models.ClubModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Data.Database;

public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public AppDbContext(DbContextOptions options) : base(options)

    {
        // Database.EnsureDeleted();
        // Database.EnsureCreated();
    }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    
    public DbSet<GameClub> GameClubs { get; set; }

    public DbSet<Equipment> Equipments { get; set; }

    public DbSet<HistoryEquip> HistoryEquips { get; set; }

    public DbSet<Photo> Photos { get; set; }

    public DbSet<Place> Places { get; set; }

    public DbSet<PlaceType> PlaceTypes { get; set; }
    
    public DbSet<Provider> Providers { get; set; }

    public DbSet<Schedule> Schedules { get; set; }
}