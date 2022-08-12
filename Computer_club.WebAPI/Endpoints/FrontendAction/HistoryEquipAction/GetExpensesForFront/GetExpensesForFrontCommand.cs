using Computer_club.Services.Options;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.HistoryEquipAction.GetExpensesForFront;

public class GetExpensesForFrontCommand : IPagination
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}