using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.User;
using Computer_club.Services.Services.ClubServices.DeviceSetService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.DeviceSetAction.Update;

public class UpdateSet : EndpointBaseAsync
    .WithRequest<UpdateSetCommand>
    .WithActionResult<UpdateSetResult>
{
    private readonly IDeviceSetService<DeviceSet> _service;
    private readonly IMapper _mapper;

    public UpdateSet(IDeviceSetService<DeviceSet> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPut("api/clubs/places/device_sets")]
    [SwaggerOperation(
        Summary = "Device set update",
        Description = "Device set update",
        OperationId = "DeviceSet.Update",
        Tags = new[] { "DeviceSetsEndpoints" })
    ]
    public override async Task<ActionResult<UpdateSetResult>> HandleAsync
        ([FromBody]UpdateSetCommand request, CancellationToken token = default)
    {
        var find = await _service.GetByIdAsync(request.Id);
        if (find == null) return NotFound();
        _mapper.Map(request, find);
        await _service.UpdateAsync(find, token);
        var result = _mapper.Map<UpdateSetResult>(find);
        return Ok(result);
    }
}