using Computer_club.Data.Models.ClubModels;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.HistoryEquipAction.GetExpensesForFront;

public class GetExpensesForFrontResult
{
    public int Sum { get; set; }
    public List<HistoryEquip>? Items { get; set; }
}