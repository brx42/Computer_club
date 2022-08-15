using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Domain.Services.ClubServices.HistoryEquipmentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.HistoryEquipAction.GetExpenses;

public class GetExpenses : EndpointBaseAsync
    .WithRequest<GetExpensesCommand>
    .WithActionResult
{
    private readonly IHistoryEquipService<HistoryEquip> _service;

    public GetExpenses(IHistoryEquipService<HistoryEquip> service)
    {
        _service = service;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpGet("api/clubs/history_equipments_expenses")]
    [SwaggerOperation(
        Summary = "History equip expenses get",
        Description = "History equip expenses get",
        OperationId = "HistoryEquipExpenses.Get",
        Tags = new[] { "HistoryEquipsEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync([FromQuery]GetExpensesCommand request, CancellationToken token = default)
    {
        GetExpensesResult res = new();
        int? sum = await _service.GetSumExpensesAsync(request.Start, request.End);
        List<HistoryEquip>? data =
            await _service.GetAllForThePeriodAsync
            (request.PageNumber, request.PageSize, request.Start, request.End);

        res.Sum = sum ?? 0;
        res.Items = data;
        return Ok(res);
    }
}