using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.ClubServices.DeviceSetService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.DeviceSetAction.Create;

public class CreateSetForFront : EndpointBaseAsync
    .WithRequest<CreateSetForFrontCommand>
    .WithActionResult<CreateSetForFrontResult>
{
    private readonly IDeviceSetService<DeviceSet> _service;
    private readonly IMapper _mapper;

    public CreateSetForFront(IDeviceSetService<DeviceSet> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPost("clubs/places/device_sets")]
    [SwaggerOperation(
        Summary = "Device set create",
        Description = "Device set create",
        OperationId = "DeviceSet.Create",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult<CreateSetForFrontResult>> HandleAsync
        ([FromBody]CreateSetForFrontCommand request, CancellationToken token = default)
    {
        var set = _mapper.Map<DeviceSet>(request);
        var result = await _service.AddAsync(set, token);
        var map = _mapper.Map<CreateSetForFrontResult>(result);
        return Created("", map);
    }
}