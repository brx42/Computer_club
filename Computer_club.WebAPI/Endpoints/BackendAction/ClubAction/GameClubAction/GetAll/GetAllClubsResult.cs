﻿namespace Computer_club.WebAPI.Endpoints.BackendAction.ClubAction.GameClubAction.GetAll;

public class GetAllClubsResult
{
    public int Id { get; set; }
    public string? Address { get; set; }
    public string? Description { get; set; }
    public bool IsOwned { get; set; }
    public string? ContractNumber { get; set; }
    public string? DigitizedDocument { get; set; }
}