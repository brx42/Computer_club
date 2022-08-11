namespace Computer_club.WebAPI.Endpoints.FrontendAction.EquipmentAction.GetAll;

public class GetAllEquipmentsForFrontResult
{
    public int Id { get; set; }
    public string DeviceType { get; set; }
    public string DeviceName { get; set; }
    public string? DevicePicturePath { get; set; }

    public int DeviceSetId { get; set; }
}