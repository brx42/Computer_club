using Computer_club.Data.Models.ClubModels;
using Computer_club.Domain.Repositories.BaseClubRepository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.DeviceSetAction.GetById;

public class GetByIdSet : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<GetByIdSetResult>
{
    private readonly IBaseClubRepository<DeviceSet> _service;
    private readonly IMapper _mapper;

    public GetByIdSet(IBaseClubRepository<DeviceSet> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("api/clubs/places/device_sets/{id}")]
    [SwaggerOperation(
        Summary = "Device set get",
        Description = "Device set get",
        OperationId = "DeviceSet.GetById",
        Tags = new[] { "DeviceSetsEndpoints" })
    ]
    public override async Task<ActionResult<GetByIdSetResult>> HandleAsync(int id, CancellationToken token = default)
    {
        var result = await _service.GetByIdAsync(id);
        var map = _mapper.Map<GetByIdSetResult>(result);
        return Ok(map);
    }
}