using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.ClubServices.HistoryEquipmentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.HistoryEquipAction.Delete;

public class DeleteHistoryForFront : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult
{
    private readonly IHistoryEquipService<HistoryEquip> _service;

    public DeleteHistoryForFront(IHistoryEquipService<HistoryEquip> service)
    {
        _service = service;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpDelete("clubs/history_equipments/{id}")]
    [SwaggerOperation(
        Summary = "History equip delete ",
        Description = "History equip delete",
        OperationId = "HistoryEquip.delete",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(int id, CancellationToken token = default)
    {
        var history = await _service.GetByIdAsync(id);
        if (history == null) return NotFound();
        var result = _service.DeleteAsync(history, token);
        return Ok(result);
    }
}