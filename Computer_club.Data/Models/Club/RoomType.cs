namespace Computer_club.Data.Models.Club;

public class RoomType
{
    public Guid Id { get; set; }
    public bool IsRented { get; set; }
    public bool IsProperty { get; set; }
    public string ContractNumber { get; set; }
    public string DigitizedDoc { get; set; }
}