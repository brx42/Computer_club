using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Services.ClubServices.DeviceSetService;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.DeviceSetAction.GetAll;

public class GetAllSetsForFront : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult
{
    private readonly IDeviceSetService<DeviceSet> _service;
    private readonly IMapper _mapper;

    public GetAllSetsForFront(IDeviceSetService<DeviceSet> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("clubs/places/device_sets")]
    [SwaggerOperation(
        Summary = "Device set get all",
        Description = "Device set get all",
        OperationId = "DeviceSet.GetAll",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(CancellationToken token = default)
    {
        var result = await _service.GetAllAsync(token);
        var map = _mapper.Map<List<GetAllSetsForFrontResult>>(result);
        return Ok(map);
    }
}