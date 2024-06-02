using ComputerClub.Domain.Options;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.HistoryEquipAction.GetExpenses;

public class GetSumExpenseHistoryEquipmentResponse : IPagination
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}