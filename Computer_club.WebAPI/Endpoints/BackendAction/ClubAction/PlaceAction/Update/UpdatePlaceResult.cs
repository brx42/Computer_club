﻿namespace Computer_club.WebAPI.Endpoints.BackendAction.ClubAction.PlaceAction.Update;

public class UpdatePlaceResult
{
    public bool IsVip { get; set; }
    public bool IsFree { get; set; }

    public int DeviceSetId { get; set; }
    public int GameClubId { get; set; }
}