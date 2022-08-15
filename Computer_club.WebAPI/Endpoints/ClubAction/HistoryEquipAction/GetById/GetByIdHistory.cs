using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Domain.Repositories.BaseClubRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.HistoryEquipAction.GetById;

public class GetByIdHistory : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<GetByIdHistoryResult>
{
    private readonly IBaseClubRepository<HistoryEquip> _service;
    private readonly IMapper _mapper;

    public GetByIdHistory(IBaseClubRepository<HistoryEquip> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpGet("api/clubs/history_equipments/{id}")]
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