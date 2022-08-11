using Computer_club.Services.Options;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.HistoryEquipAction.GetAllForThePeriod;

public class GetAllHistoriesForThePeriodForFrontCommand
{
    public Pagination Pagination { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}