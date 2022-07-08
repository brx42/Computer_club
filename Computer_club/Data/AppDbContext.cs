using Ardalis.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Computer_club.Models.UserModel;

namespace Computer_club.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();
    }
}