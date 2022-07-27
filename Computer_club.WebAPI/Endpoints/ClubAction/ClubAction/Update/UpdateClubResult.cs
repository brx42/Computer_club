using Computer_club.Data.Models.Club;

namespace Computer_club.WebAPI.Endpoints.ClubAction.ClubAction.Update;

public class UpdateClubResult
{
    public string? AddressClub { get; set; }
    public string? Description { get; set; }
    public bool? IsRented { get; set; }
    public bool? IsProperty { get; set; }
    public string? ContractNumber { get; set; }
    public string? DigitizedDoc { get; set; }
    public string[]? PhotoGallery { get; set; }
    public EquipmentClub? EquipmentClub { get; set; }
    public Provider? Provider { get; set; }
    public HistoryRepairEquipment? HistoryRepairEquipment { get; set; }
    public Schedule? Schedule { get; set; }
}