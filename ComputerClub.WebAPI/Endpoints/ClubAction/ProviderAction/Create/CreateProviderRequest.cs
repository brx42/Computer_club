﻿namespace ComputerClub.WebAPI.Endpoints.ClubAction.ProviderAction.Create;

public class CreateProviderRequest
{
    public string Name { get; set; }
    public string Speed { get; set; }
    public string Price { get; set; }
    public bool IsStaticIP { get; set; }
    public string? ContractNumber { get; set; }
    public int GameClubId { get; set; }
}