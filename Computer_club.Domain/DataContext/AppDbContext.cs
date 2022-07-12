using Ardalis.EFCore.Extensions;
using Computer_club.Domain.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Domain.DataContext;

public class AppDbContext : IdentityDbContext<UserModel>
{
    public DbSet<UserModel> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();
    }
}