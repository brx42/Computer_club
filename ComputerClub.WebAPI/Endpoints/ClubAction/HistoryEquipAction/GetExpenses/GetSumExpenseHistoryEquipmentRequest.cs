using ComputerClub.DAL.Models.ClubModels;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.HistoryEquipAction.GetExpenses;

public class GetSumExpenseHistoryEquipmentRequest
{
    public int Sum { get; set; }
    public List<HistoryEquip>? Items { get; set; }
}