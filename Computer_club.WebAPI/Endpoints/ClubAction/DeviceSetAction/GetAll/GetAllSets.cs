using Computer_club.Data.Models.ClubModels;
using Computer_club.Domain.Options;
using Computer_club.Domain.Repositories.BaseClubRepository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.DeviceSetAction.GetAll;

public class GetAllSets : EndpointBaseAsync
    .WithRequest<Pagination>
    .WithActionResult
{
    private readonly IBaseClubRepository<DeviceSet> _service;
    private readonly IMapper _mapper;

    public GetAllSets(IBaseClubRepository<DeviceSet> service, IMapper mapper)
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
    public override async Task<ActionResult> HandleAsync([FromQuery]Pagination pagination, CancellationToken token = default)
    {
        var result = await _service.GetAllAsync(pagination, token);
        var map = _mapper.Map<List<GetAllSetsResult>>(result);
        return Ok(map);
    }
}