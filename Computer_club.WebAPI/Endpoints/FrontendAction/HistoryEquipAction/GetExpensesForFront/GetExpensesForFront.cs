using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Options;
using Computer_club.Services.Services.ClubServices.HistoryEquipmentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.HistoryEquipAction.GetExpensesForFront;

public class GetExpensesForFront : EndpointBaseAsync
    .WithRequest<GetExpensesForFrontCommand>
    .WithActionResult
{
    private readonly IHistoryEquipService<HistoryEquip> _service;
    private readonly IMapper _mapper;

    public GetExpensesForFront(IHistoryEquipService<HistoryEquip> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpGet("clubs/history_equipments_expenses")]
    [SwaggerOperation(
        Summary = "History equip expenses get",
        Description = "History equip expenses get",
        OperationId = "HistoryEquipExpenses.Get",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync([FromQuery]GetExpensesForFrontCommand request, CancellationToken token = default)
    {
        GetExpensesForFrontResult res = new();
        int? sum = await _service.GetSumExpensesAsync(request.Start, request.End);
        List<HistoryEquip>? data =
            await _service.GetAllForThePeriodAsync
            (request.PageNumber, request.PageSize, request.Start, request.End);

        res.Sum = sum ?? 0;
        res.Items = data;
        return Ok(res);
    }
}