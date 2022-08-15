using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Domain.Repositories.BaseClubRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.HistoryEquipAction.Create;

public class CreateHistory : EndpointBaseAsync
    .WithRequest<CreateHistoryCommand>
    .WithActionResult<CreateHistoryResult>
{
    private readonly IBaseClubRepository<HistoryEquip> _service;
    private readonly IMapper _mapper;

    public CreateHistory(IBaseClubRepository<HistoryEquip> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPost("api/clubs/history_equipments")]
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