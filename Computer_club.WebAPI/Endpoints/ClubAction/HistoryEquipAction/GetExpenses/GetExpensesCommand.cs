using Computer_club.Domain.Options;

namespace Computer_club.WebAPI.Endpoints.ClubAction.HistoryEquipAction.GetExpenses;

public class GetExpensesCommand : IPagination
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}