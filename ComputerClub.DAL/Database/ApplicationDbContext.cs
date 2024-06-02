using ComputerClub.DAL.Entities;
using ComputerClub.DAL.Models.ClubModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComputerClub.DAL.Database;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)

    {
        // Database.EnsureDeleted();
        // Database.EnsureCreated();
        
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
    public DbSet<RefreshToken> RefreshToken { get; set; }

    public DbSet<GameEntity> GameClub { get; set; }

    public DbSet<Equipment> Equipment { get; set; }

    public DbSet<HistoryEquip> HistoryEquip { get; set; }

    public DbSet<Photo> Photo { get; set; }

    public DbSet<Place> Place { get; set; }

    public DbSet<DeviceSet> DeviceSet { get; set; }
    
    public DbSet<Provider> Provider { get; set; }

    public DbSet<Schedule> Schedule { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<GameEntity>()
            .HasMany(x => x.Users)
            .WithMany(x => x.GameClubs)
            .UsingEntity(x => x.ToTable("ClubUsers"));

        builder.Entity<Equipment>()
            .HasOne(x => x.GameEntity)
            .WithMany(x => x.Equipments)
            .HasForeignKey(x => x.GameClubId);

        builder.Entity<DeviceSet>()
            .HasOne(x => x.GameEntity)
            .WithMany(x => x.DeviceSets)
            .HasForeignKey(x => x.GameClubId);
        
        builder.Entity<Provider>()
            .HasOne(x => x.GameEntity)
            .WithOne(x => x.Provider)
            .HasForeignKey<Provider>(x => x.GameClubId);
        
        builder.Entity<HistoryEquip>()
            .HasOne(x => x.GameEntity)
            .WithMany(x => x.HistoryEquips)
            .HasForeignKey(x => x.GameClubId);
        
        builder.Entity<Schedule>()
            .HasOne(x => x.GameEntity)
            .WithMany(x => x.Schedules)
            .HasForeignKey(x => x.GameClubId);
        
        builder.Entity<Photo>()
            .HasOne(x => x.GameEntity)
            .WithMany(x => x.Photos)
            .HasForeignKey(x => x.GameClubId);
        
        builder.Entity<Place>()
            .HasOne(x => x.GameEntity)
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