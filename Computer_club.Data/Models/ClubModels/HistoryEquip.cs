﻿using Computer_club.Data.Entities;

namespace Computer_club.Data.Models.ClubModels;

public class HistoryEquip : BaseClub
{
    public DateTime DateOfWork { get; set; }
    public string TypeOfWork { get; set; }
    public string DeviceName { get; set; }
    public int? PriceOfWork { get; set; }
    public string ReasonForWork { get; set; }
    
    public int GameClubId { get; set; }
    public GameClub GameClub { get; set; }
}