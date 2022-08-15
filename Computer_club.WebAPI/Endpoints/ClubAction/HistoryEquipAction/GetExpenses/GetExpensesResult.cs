using Computer_club.Data.Models.ClubModels;

namespace Computer_club.WebAPI.Endpoints.ClubAction.HistoryEquipAction.GetExpenses;

public class GetExpensesResult
{
    public int Sum { get; set; }
    public List<HistoryEquip>? Items { get; set; }
}