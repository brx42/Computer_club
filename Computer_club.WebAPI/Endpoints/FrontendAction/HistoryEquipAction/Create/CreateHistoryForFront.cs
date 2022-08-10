using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.ClubServices.HistoryEquipmentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.HistoryEquipAction.Create;

public class CreateHistoryForFront : EndpointBaseAsync
    .WithRequest<CreateHistoryForFrontCommand>
    .WithActionResult<CreateHistoryForFrontResult>
{
    private readonly IHistoryEquipService<HistoryEquip> _service;
    private readonly IMapper _mapper;

    public CreateHistoryForFront(IHistoryEquipService<HistoryEquip> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPost("clubs/history_equipments")]
    [SwaggerOperation(
        Summary = "History equip create",
        Description = "History equip create",
        OperationId = "HistoryEquip.Create",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult<CreateHistoryForFrontResult>> HandleAsync
        ([FromBody]CreateHistoryForFrontCommand request, CancellationToken token = default)
    {
        var history = _mapper.Map<HistoryEquip>(request);
        var result = await _service.AddAsync(history, token);
        var map = _mapper.Map<CreateHistoryForFrontResult>(result);
        return Created("", map);
    }
}