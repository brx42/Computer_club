using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Services.ClubServices.DeviceSetService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.DeviceSetAction.GetAll;

public class GetAllSets : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult
{
    private readonly IDeviceSetService<DeviceSet> _service;
    private readonly IMapper _mapper;

    public GetAllSets(IDeviceSetService<DeviceSet> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("api/clubs/places/device_sets")]
    [SwaggerOperation(
        Summary = "Device set get all",
        Description = "Device set get all",
        OperationId = "DeviceSet.GetAll",
        Tags = new[] { "DeviceSetsEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(CancellationToken token = default)
    {
        var result = await _service.GetAllAsync(token);
        var map = _mapper.Map<List<GetAllSetsResult>>(result);
        return Ok(map);
    }
}