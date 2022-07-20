namespace Computer_club.Domain.Data;

public class Authorization
{
    public const string DefaultUsername = "User";
    public const string DefaultEmail = "User@localhost.ru";
    public const string DefaultPassword = "UserPassword";
    public const Roles DefaultRoles = Roles.Client;
    
    
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