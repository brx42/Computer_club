﻿namespace Computer_club.WebAPI.Endpoints.FrontendAction.PlaceAction.GetAllVip;

public class GetAllVipPlacesForFrontResult
{
    public int Id { get; set; }
    public bool IsVip { get; set; }
    public bool IsFree { get; set; }

    public int DeviceSetId { get; set; }
    public int GameClubId { get; set; }
}