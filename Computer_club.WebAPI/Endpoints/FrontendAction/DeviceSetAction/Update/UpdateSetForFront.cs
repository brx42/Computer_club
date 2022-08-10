using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.ClubServices.DeviceSetService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.DeviceSetAction.Update;

public class UpdateSetForFront : EndpointBaseAsync
    .WithRequest<UpdateSetForFrontCommand>
    .WithActionResult<UpdateSetForFrontResult>
{
    private readonly IDeviceSetService<DeviceSet> _service;
    private readonly IMapper _mapper;

    public UpdateSetForFront(IDeviceSetService<DeviceSet> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPut("clubs/places/device_sets")]
    [SwaggerOperation(
        Summary = "Device set update",
        Description = "Device set update",
        OperationId = "DeviceSet.Update",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult<UpdateSetForFrontResult>> HandleAsync
        ([FromBody]UpdateSetForFrontCommand request, CancellationToken token = default)
    {
        var find = await _service.GetByIdAsync(request.Id);
        if (find == null) return NotFound();
        _mapper.Map(request, find);
        await _service.UpdateAsync(find, token);
        var result = _mapper.Map<UpdateSetForFrontResult>(find);
        return Ok(result);
    }
}