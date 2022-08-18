using Computer_club.Data.Entities;
using Computer_club.Data.Models.UserModels;
using Computer_club.Domain.Options;
using Computer_club.Domain.Repositories.BaseClubRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.GameClubAction.GetAll;

public class GetAllClubs : EndpointBaseAsync
    .WithRequest<Pagination>
    .WithActionResult
{
    private readonly IBaseClubRepository<GameClub> _service;
    private readonly IMapper _mapper;

    public GetAllClubs(IBaseClubRepository<GameClub> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpGet("api/clubs")]
    [SwaggerOperation(
        Summary = "Club get all",
        Description = "Club get all",
        OperationId = "Club.GetAll",
        Tags = new[] { "ClubsEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync([FromQuery]Pagination pagination, CancellationToken token = default)
    {
        var result = await _service.GetAllAsync(pagination, token);
        var map = _mapper.Map<List<GetAllClubsResult>>(result);
        return Ok(map);
    }
}