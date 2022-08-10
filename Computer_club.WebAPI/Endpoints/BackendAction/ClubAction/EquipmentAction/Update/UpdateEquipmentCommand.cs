namespace Computer_club.WebAPI.Endpoints.BackendAction.ClubAction.EquipmentAction.Update;

public class UpdateEquipmentCommand
{
    public int Id { get; set; }
    public string DeviceType { get; set; }
    public string DeviceName { get; set; }
    public string? DevicePicturePath { get; set; }

    public int DeviceSetId { get; set; }
}