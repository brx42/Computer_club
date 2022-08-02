﻿using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Services.ClubServices.HistoryEquipmentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.HistoryEquipAction.Delete;

public class DeleteHistory : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult
{
    private readonly IHistoryEquipService<HistoryEquip> _service;

    public DeleteHistory(IHistoryEquipService<HistoryEquip> service)
    {
        _service = service;
    }

    [HttpDelete("api/club/history_equipment/{id}")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "History equip delete ",
        Description = "History equip delete",
        OperationId = "HistoryEquip.delete",
        Tags = new[] { "HistoryEquipmentEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(int id, CancellationToken token = default)
    {
        var history = await _service.GetByIdAsync(id);
        if (history == null) return NotFound();
        var result = _service.DeleteAsync(history, token);
        return Ok(result);
    }
}