﻿namespace Computer_club.WebAPI.Endpoints.FrontendAction.PlaceAction.Create;

public class CreatePlaceForFrontResult
{
    public int Id { get; set; }
    public bool IsVip { get; set; }
    public bool IsFree { get; set; }

    public int DeviceSetId { get; set; }
    public int GameClubId { get; set; }
}