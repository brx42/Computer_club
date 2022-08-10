using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.ClubServices.DeviceSetService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.DeviceSetAction.Delete;

public class DeleteSetForFront : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult
{
    private readonly IDeviceSetService<DeviceSet> _service;

    public DeleteSetForFront(IDeviceSetService<DeviceSet> service)
    {
        _service = service;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpDelete("clubs/places/device_sets/{id}")]
    [SwaggerOperation(
        Summary = "Device set delete ",
        Description = "Device set delete",
        OperationId = "DeviceSet.delete",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(int id, CancellationToken token = default)
    {
        var find = await _service.GetByIdAsync(id);
        if (find == null) return NotFound();
        var result = _service.DeleteAsync(find, token);
        return Ok(result);
    }
}