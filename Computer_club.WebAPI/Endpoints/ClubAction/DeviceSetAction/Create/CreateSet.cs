using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Services.ClubServices.DeviceSetService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.DeviceSetAction.Create;

public class CreateSet : EndpointBaseAsync
    .WithRequest<CreateSetCommand>
    .WithActionResult<CreateSetResult>
{
    private readonly IDeviceSetService<DeviceSet> _service;
    private readonly IMapper _mapper;

    public CreateSet(IDeviceSetService<DeviceSet> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost("api/clubs/places/device_sets")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Device set create",
        Description = "Device set create",
        OperationId = "DeviceSet.Create",
        Tags = new[] { "DeviceSetsEndpoints" })
    ]
    public override async Task<ActionResult<CreateSetResult>> HandleAsync
        ([FromBody]CreateSetCommand request, CancellationToken token = default)
    {
        var set = _mapper.Map<DeviceSet>(request);
        var result = await _service.AddAsync(set, token);
        var map = _mapper.Map<CreateSetResult>(result);
        return Created("", map);
    }
}