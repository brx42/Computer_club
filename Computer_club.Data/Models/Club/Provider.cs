namespace Computer_club.Data.Models.Club;

public class Provider
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Speed { get; set; }
    public string Price { get; set; }
    public bool IsStatic { get; set; }
    public string ContractNumber { get; set; }
}