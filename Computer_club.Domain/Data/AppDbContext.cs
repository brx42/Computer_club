using Ardalis.EFCore.Extensions;
using Computer_club.Domain.Data.Entities;
using Computer_club.Domain.Data.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Domain.Data;

public class AppDbContext : DbContext
{
    public DbSet<UserModel> Users { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<RoleModel> Roles { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();
    }
}