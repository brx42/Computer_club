using Computer_club.Data.Entities.ClubEntities;
using Computer_club.Services.Services.ClubServices.ClubService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.GameClubAction.GetAll;

public class GetAllClubs : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult
{
    private readonly IClubService<GameClub> _service;
    private readonly IMapper _mapper;

    public GetAllClubs(IClubService<GameClub> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("api/club")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Club get all",
        Description = "Club get all",
        OperationId = "Club.GetAll",
        Tags = new[] { "ClubEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(CancellationToken token = default)
    {
        var result = await _service.GetAllAsync(token);
        var map = _mapper.Map<List<GetAllClubsResult>>(result);
        return Ok(map);
    }
}