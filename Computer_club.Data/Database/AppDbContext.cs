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

    public AppDbContext()
    {
        
    }
    
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    
    public DbSet<GameClub> GameClubs { get; set; }

    public DbSet<Equipment> Equipments { get; set; }

    public DbSet<HistoryEquip> HistoryEquips { get; set; }

    public DbSet<Photo> Photos { get; set; }

    public DbSet<Place> Places { get; set; }

    public DbSet<DeviceSet> DeviceSets { get; set; }
    
    public DbSet<Provider> Providers { get; set; }

    public DbSet<Schedule> Schedules { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Provider>()
            .HasOne(p => p.GameClub)
            .WithOne(p => p.Provider)
            .HasForeignKey<Provider>(p => p.GameClubId);
        
        builder.Entity<HistoryEquip>()
            .HasOne(i => i.GameClub)
            .WithMany(i => i.HistoryEquips)
            .HasForeignKey(i => i.GameClubId);
        
        builder.Entity<Schedule>()
            .HasOne(d => d.GameClub)
            .WithMany(d => d.Schedules)
            .HasForeignKey(d => d.GameClubId);
        
        builder.Entity<Photo>()
            .HasOne(o => o.GameClub)
            .WithMany(o => o.Photos)
            .HasForeignKey(o => o.GameClubId);
        
        builder.Entity<Place>()
            .HasOne(r => r.GameClub)
            .WithMany(r => r.Places)
            .HasForeignKey(r => r.GameClubId);
        
        builder.Entity<Equipment>()
            .HasOne(a => a.DeviceSet)
            .WithMany(a => a.Equipments)
            .HasForeignKey(a => a.DeviceSetId);
        
        builder.Entity<Place>()
            .HasOne(s => s.DeviceSet)
            .WithOne(s => s.Place)
            .HasForeignKey<Place>(s => s.DeviceSetId);
    }
}