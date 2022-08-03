using Computer_club.Data.Entities.ClubEntities;
using Computer_club.Data.Models.User;
using Computer_club.Services.Services.ClubServices.ClubService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.GameClubAction.GetById;

public class GetByIdClub : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult
{
    private readonly IClubService<GameClub> _service;
    private readonly IMapper _mapper;

    public GetByIdClub(IClubService<GameClub> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpGet("api/clubs/{id}")]
    [SwaggerOperation(
        Summary = "Club get",
        Description = "Club get",
        OperationId = "Club.GetById",
        Tags = new[] { "ClubsEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(int id, CancellationToken token = default)
    {
        var result = await _service.GetByIdAsync(id);
        var map = _mapper.Map<GetByIdClubResult>(result);
        return Ok(map);
    }
}