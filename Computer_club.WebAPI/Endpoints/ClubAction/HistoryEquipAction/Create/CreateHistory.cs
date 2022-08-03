using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Services.ClubServices.HistoryEquipmentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.HistoryEquipAction.Create;

public class CreateHistory : EndpointBaseAsync
    .WithRequest<CreateHistoryCommand>
    .WithActionResult<CreateHistoryResult>
{
    private readonly IHistoryEquipService<HistoryEquip> _service;
    private readonly IMapper _mapper;

    public CreateHistory(IHistoryEquipService<HistoryEquip> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    [HttpPost("api/clubs/history_equipments")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "History equip create",
        Description = "History equip create",
        OperationId = "HistoryEquip.Create",
        Tags = new[] { "HistoryEquipsEndpoints" })
    ]
    public override async Task<ActionResult<CreateHistoryResult>> HandleAsync
        ([FromBody]CreateHistoryCommand request, CancellationToken token = default)
    {
        var history = _mapper.Map<HistoryEquip>(request);
        var result = await _service.AddAsync(history, token);
        var map = _mapper.Map<CreateHistoryResult>(result);
        return Created("", map);
    }
}