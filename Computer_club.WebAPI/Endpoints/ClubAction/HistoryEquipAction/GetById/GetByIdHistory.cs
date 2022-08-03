using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Services.ClubServices.HistoryEquipmentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.HistoryEquipAction.GetById;

public class GetByIdHistory : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<GetByIdHistoryResult>
{
    private readonly IHistoryEquipService<HistoryEquip> _service;
    private readonly IMapper _mapper;

    public GetByIdHistory(IHistoryEquipService<HistoryEquip> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("api/clubs/history_equipments/{id}")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "History equip get",
        Description = "History equip get",
        OperationId = "HistoryEquip.GetById",
        Tags = new[] { "HistoryEquipsEndpoints" })
    ]
    public override async Task<ActionResult<GetByIdHistoryResult>> HandleAsync(int id, CancellationToken token = default)
    {
        var history = await _service.GetByIdAsync(id);
        var result = _mapper.Map<GetByIdHistoryResult>(history);
        return Ok(result);
    }
}