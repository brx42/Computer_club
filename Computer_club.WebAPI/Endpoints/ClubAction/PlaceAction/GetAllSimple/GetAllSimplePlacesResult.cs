﻿namespace Computer_club.WebAPI.Endpoints.ClubAction.PlaceAction.GetAllSimple;

public class GetAllSimplePlacesResult
{
    public int Id { get; set; }
    public bool IsVip { get; set; }
    public bool IsFree { get; set; }

    public int DeviceSetId { get; set; }
    public int GameClubId { get; set; }
}