﻿namespace Computer_club.WebAPI.Endpoints.ClubAction.EquipmentAction.Update;

public class UpdateEquipmentResult
{
    public string DeviceType { get; set; }
    public string DeviceName { get; set; }
    public string? DevicePicturePath { get; set; }

    public int DeviceSetId { get; set; }
}