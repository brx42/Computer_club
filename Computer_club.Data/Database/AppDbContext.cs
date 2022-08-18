using Computer_club.Data.Entities;
using Computer_club.Data.Models.ClubModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Data.Database;

public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)

    {
        // Database.EnsureDeleted();
        // Database.EnsureCreated();
        
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
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

        builder.Entity<GameClub>()
            .HasMany(x => x.Users)
            .WithMany(x => x.GameClubs)
            .UsingEntity(x => x.ToTable("ClubUsers"));

        builder.Entity<Equipment>()
            .HasOne(x => x.GameClub)
            .WithMany(x => x.Equipments)
            .HasForeignKey(x => x.GameClubId);

        builder.Entity<DeviceSet>()
            .HasOne(x => x.GameClub)
            .WithMany(x => x.DeviceSets)
            .HasForeignKey(x => x.GameClubId);
        
        builder.Entity<Provider>()
            .HasOne(x => x.GameClub)
            .WithOne(x => x.Provider)
            .HasForeignKey<Provider>(x => x.GameClubId);
        
        builder.Entity<HistoryEquip>()
            .HasOne(x => x.GameClub)
            .WithMany(x => x.HistoryEquips)
            .HasForeignKey(x => x.GameClubId);
        
        builder.Entity<Schedule>()
            .HasOne(x => x.GameClub)
            .WithMany(x => x.Schedules)
            .HasForeignKey(x => x.GameClubId);
        
        builder.Entity<Photo>()
            .HasOne(x => x.GameClub)
            .WithMany(x => x.Photos)
            .HasForeignKey(x => x.GameClubId);
        
        builder.Entity<Place>()
            .HasOne(x => x.GameClub)
            .WithMany(x => x.Places)
            .HasForeignKey(x => x.GameClubId);
        
        builder.Entity<Equipment>()
            .HasOne(x => x.DeviceSet)
            .WithMany(x => x.Equipments)
            .HasForeignKey(x => x.DeviceSetId);
        
        builder.Entity<Place>()
            .HasOne(x => x.DeviceSet)
            .WithMany(x => x.Place)
            .HasForeignKey(x => x.DeviceSetId);
    }
}