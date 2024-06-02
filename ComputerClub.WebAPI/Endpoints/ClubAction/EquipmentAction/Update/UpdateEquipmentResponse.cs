namespace ComputerClub.WebAPI.Endpoints.ClubAction.EquipmentAction.Update;

public class UpdateEquipmentResponse
{
    public string DeviceType { get; set; }
    public string DeviceName { get; set; }
    public string? DevicePicturePath { get; set; }

    public int DeviceSetId { get; set; }
}