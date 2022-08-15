using Computer_club.Data.Database;
using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Domain.Repositories.BaseClubRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.DeviceSetAction.Create;

public class CreateSet : EndpointBaseAsync
    .WithRequest<CreateSetCommand>
    .WithActionResult<CreateSetResult>
{
    private readonly IBaseClubRepository<DeviceSet> _service;
    private readonly IMapper _mapper;

    public CreateSet(IBaseClubRepository<DeviceSet> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPost("api/clubs/places/device_sets")]
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