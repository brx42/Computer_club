﻿namespace Computer_club.WebAPI.Endpoints.ClubAction.ProviderAction.GetAll;

public class GetAllProvidersResult
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Speed { get; set; }
    public string Price { get; set; }
    public bool IsStatic { get; set; }
    public string? ContractNumber { get; set; }
    public int GameClubId { get; set; }
}