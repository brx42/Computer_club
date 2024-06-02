using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Services.ClubServices.HistoryEquipmentService;
using FastEndpoints;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.HistoryEquipAction.GetExpenses;

public class GetSumExpenseHistoryEquipmentHandle : Endpoint<GetSumExpenseHistoryEquipmentRequest, GetSumExpenseHistoryEquipmentResponse>
{
    private readonly IHistoryEquipService<HistoryEquip> _service;

    public GetSumExpenseHistoryEquipmentHandle(IHistoryEquipService<HistoryEquip> service)
    {
        _service = service;
    }

    public override void Configure()
    {
        Get("club/history-equipment-expense");

        Summary(sum => { sum.Summary = "History equipment expenses get"; });
        
        Options(opt => opt.WithTags("HistoryEquipment"));

        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(GetSumExpenseHistoryEquipmentRequest request, CancellationToken ct)
    {
        // GetSumExpenseHistoryEquipmentResponse res = new();
        // int? sum = await _service.GetSumExpensesAsync(request.Start, request.End);
        // List<HistoryEquip>? data =
        //     await _service.GetAllForThePeriodAsync
        //         (request.PageNumber, request.PageSize, request.Start, request.End);
        //
        // res.Sum = sum ?? 0;
        // res.Items = data;
        // return Ok(res);
    }
}