using Computer_club.Data.Models.Club;

namespace Computer_club.Data.Entities.Club;

public class Club
{
    public Guid ClubId { get; set; }
    public AddressClub? AddressClub { get; set; }
    public DescriptionClub? Description { get; set; }
    public Provider? Provider { get; set; }
    public EquipmentSeat? EquipmentSeat { get; set; }
    public HistoryRepairEquipment? HistoryRepairEquipment { get; set; }
    public PhotoGallery? PhotoGallery { get; set; }
    public RoomType? RoomType { get; set; }
    public Schedule? Schedule { get; set; }
}