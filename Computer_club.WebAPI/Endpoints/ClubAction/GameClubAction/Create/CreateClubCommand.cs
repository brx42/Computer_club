﻿namespace Computer_club.WebAPI.Endpoints.ClubAction.GameClubAction.Create;

public class CreateClubCommand
{
    public string? Address { get; set; }
    public string? Description { get; set; }
    public bool IsOwned { get; set; }
    public string? ContractNumber { get; set; }
    public string? DigitizedDocument { get; set; }
}