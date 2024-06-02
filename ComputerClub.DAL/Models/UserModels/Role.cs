namespace ComputerClub.DAL.Models.UserModels;

public static class Role
{
    public const string SuperAdmin = "SuperAdmin";
    public const string Manager = "Manager";
    public const string Support = "Support";
    public const string Client = "Client";
    public const string ClubAdmin = "ClubAdmin";
    public const string SiteAdmin = "SiteAdmin";
    public const string Analyst = "Analyst";
    public const string Auditor = "Auditor";

    public static readonly string[] AllAdmins =
    [
        SuperAdmin,
        Manager,
        Support,
        ClubAdmin,
        SiteAdmin
    ];

    public static readonly string[] SuperAdminAndManager =
    [
        SuperAdmin,
        Manager
    ];
}