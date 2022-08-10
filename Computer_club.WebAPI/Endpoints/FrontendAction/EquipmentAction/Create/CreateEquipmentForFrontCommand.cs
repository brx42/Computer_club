namespace Computer_club.WebAPI.Endpoints.FrontendAction.EquipmentAction.Create;

public class CreateEquipmentForFrontCommand
{
    public string DeviceType { get; set; }
    public string DeviceName { get; set; }
    public string? DevicePicturePath { get; set; }

    public int DeviceSetId { get; set; }
}