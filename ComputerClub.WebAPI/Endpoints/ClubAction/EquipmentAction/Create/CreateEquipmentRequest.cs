namespace ComputerClub.WebAPI.Endpoints.ClubAction.EquipmentAction.Create;

public class CreateEquipmentRequest
{
    public string DeviceType { get; set; }
    public string DeviceName { get; set; }
    public string? DevicePicturePath { get; set; }

    public int DeviceSetId { get; set; }
}