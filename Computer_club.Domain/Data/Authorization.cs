namespace Computer_club.Domain.Data;

public class Authorization
{
    public const string SuperAdminUsername = "SuperAdmin";
    public const string SuperAdminEmail = "SuperAdmin@localhost.ru";
    public const string SuperAdminPassword = "SuperAdmin123.";
    public const Roles SuperAdminRoles = Roles.SuperAdmin;
    
    
    public enum Roles
    {
        SuperAdmin,
        Manager,
        Support,
        Client,
        ClubAdmin,
        SiteAdmin,
        Analyst,
        Auditor
    }
}