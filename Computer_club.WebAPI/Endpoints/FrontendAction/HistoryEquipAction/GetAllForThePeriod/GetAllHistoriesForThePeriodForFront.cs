using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.ClubServices.HistoryEquipmentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.HistoryEquipAction.GetAllForThePeriod;

public class GetAllHistoriesForThePeriodForFront : EndpointBaseAsync
    .WithRequest<GetAllHistoriesForThePeriodForFrontCommand>
    .WithActionResult
{
    private readonly IHistoryEquipService<HistoryEquip> _service;
    private readonly IMapper _mapper;

    public GetAllHistoriesForThePeriodForFront(IHistoryEquipService<HistoryEquip> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpGet("clubs/history_equipments_on_time")]
    [SwaggerOperation(
        Summary = "History equip on time get all",
        Description = "History equip on time get all",
        OperationId = "HistoryEquipOnTime.GetAll",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync([FromQuery]GetAllHistoriesForThePeriodForFrontCommand request,
        CancellationToken token = default)
    {
        var action = await _service.GetAllForThePeriodAsync(request.Pagination, request.Start.Date, request.End.Date);
        var result = _mapper.Map<List<GetAllHistoriesForThePeriodForFrontResult>>(action);
        return Ok(result);
    }
}