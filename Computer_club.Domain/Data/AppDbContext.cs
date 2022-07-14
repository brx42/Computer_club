using Ardalis.EFCore.Extensions;
using Computer_club.Domain.Data.Entities;
using Computer_club.Domain.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Computer_club.Domain.Data;

public class AppDbContext : DbContext
{
    public DbSet<User>? Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();

        builder.Entity<Role>().HasData(
            new Role {Id = 1, Name = RoleEnum.SuperAdministrator},
            new Role {Id = 2, Name = RoleEnum.Manager},
            new Role {Id = 3, Name = RoleEnum.Support},
            new Role {Id = 4, Name = RoleEnum.ClubClient},
            new Role {Id = 5, Name = RoleEnum.ClubAdministrator},
            new Role {Id = 6, Name = RoleEnum.SiteAdministrator},
            new Role {Id = 7, Name = RoleEnum.BusinessAnalyst},
            new Role {Id = 8, Name = RoleEnum.Auditor}
        );
    }
}