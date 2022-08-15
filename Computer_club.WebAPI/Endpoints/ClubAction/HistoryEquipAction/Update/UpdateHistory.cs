using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Domain.Repositories.BaseClubRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.HistoryEquipAction.Update;

public class UpdateHistory : EndpointBaseAsync
    .WithRequest<UpdateHistoryCommand>
    .WithActionResult<UpdateHistoryResult>
{
    private readonly IBaseClubRepository<HistoryEquip> _service;
    private readonly IMapper _mapper;

    public UpdateHistory(IBaseClubRepository<HistoryEquip> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPut("api/clubs/history_equipments")]
    [SwaggerOperation(
        Summary = "History equip update",
        Description = "History equip update",
        OperationId = "HistoryEquip.Update",
        Tags = new[] { "HistoryEquipsEndpoints" })
    ]
    public override async Task<ActionResult<UpdateHistoryResult>> HandleAsync
        ([FromBody]UpdateHistoryCommand request, CancellationToken token = default)
    {
        var find = await _service.GetByIdAsync(request.Id);
        if (find == null) return NotFound();
        _mapper.Map(request, find);
        await _service.UpdateAsync(find, token);
        var result = _mapper.Map<UpdateHistoryResult>(find);
        return Ok(result);
    }
}