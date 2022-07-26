namespace Computer_club.Data.Models.Club;

public class Schedule
{
    public Guid Id { get; set; }
    public int AmountSeat { get; set; }
    public int AmountVipSeat { get; set; }
    public int AmountFreeSeat { get; set; }
    public string SeatTariff { get; set; }
}