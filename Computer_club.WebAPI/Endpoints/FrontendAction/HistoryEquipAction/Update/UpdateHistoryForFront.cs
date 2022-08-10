using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.ClubServices.HistoryEquipmentService;
using Computer_club.WebAPI.Endpoints.BackendAction.ClubAction.HistoryEquipAction.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.HistoryEquipAction.Update;

public class UpdateHistoryForFront : EndpointBaseAsync
    .WithRequest<UpdateHistoryForFrontCommand>
    .WithActionResult<UpdateHistoryForFrontResult>
{
    private readonly IHistoryEquipService<HistoryEquip> _service;
    private readonly IMapper _mapper;

    public UpdateHistoryForFront(IHistoryEquipService<HistoryEquip> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPut("clubs/history_equipments")]
    [SwaggerOperation(
        Summary = "History equip update",
        Description = "History equip update",
        OperationId = "HistoryEquip.Update",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult<UpdateHistoryForFrontResult>> HandleAsync
        ([FromBody]UpdateHistoryForFrontCommand request, CancellationToken token = default)
    {
        var find = await _service.GetByIdAsync(request.Id);
        if (find == null) return NotFound();
        _mapper.Map(request, find);
        await _service.UpdateAsync(find, token);
        var result = _mapper.Map<UpdateHistoryForFrontResult>(find);
        return Ok(result);
    }
}