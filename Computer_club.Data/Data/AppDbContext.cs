using Computer_club.Data.Entities.Club;
using Computer_club.Data.Entities.User;
using Computer_club.Data.Models.Club;
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
    public DbSet<AddressClub> AddressClubs { get; set; }
    public DbSet<EquipmentSeat> EquipmentSeats { get; set; }
    public DbSet<HistoryRepairEquipment> HistoryRepairEquipments { get; set; }
    public DbSet<PhotoGallery> PhotoGalleries { get; set; }
    public DbSet<Provider> Providers { get; set; }
    public DbSet<RoomType> RoomTypes { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
}