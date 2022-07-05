using Microsoft.EntityFrameworkCore;
using Computer_club.Models.UserModels;

namespace Computer_club.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null;
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
}