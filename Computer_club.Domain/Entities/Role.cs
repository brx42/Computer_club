using Microsoft.AspNetCore.Identity;

namespace Computer_club.Domain.Entities;

public class Role : IdentityRole<Guid>
{
    public const string SuperAdmin = "SuperAdmin";
    public const string Manager = "Manager";
    public const string Support = "Support";
    public const string Client = "Client";
    public const string ClubAdmin = "ClubAdmin";
    public const string SiteAdmin = "SiteAdmin";
    public const string Analyst = "Analyst";
    public const string Auditor = "Auditor";
}