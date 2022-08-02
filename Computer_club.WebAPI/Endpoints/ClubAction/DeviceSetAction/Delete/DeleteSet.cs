﻿using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Services.ClubServices.DeviceSetService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.DeviceSetAction.Delete;

public class DeleteSet : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult
{
    private readonly IDeviceSetService<DeviceSet> _service;

    public DeleteSet(IDeviceSetService<DeviceSet> service)
    {
        _service = service;
    }

    [HttpDelete("api/club/place/device_set/{id}")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Device set delete ",
        Description = "Device set delete",
        OperationId = "DeviceSet.delete",
        Tags = new[] { "DeviceSetEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(int id, CancellationToken token = default)
    {
        var find = await _service.GetByIdAsync(id);
        if (find == null) return NotFound();
        var result = _service.DeleteAsync(find, token);
        return Ok(result);
    }
}