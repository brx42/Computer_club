using Computer_club.Services.Services.ClubServices.ClubService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Computer_club.Data.Entities.ClubEntities;
using Computer_club.Data.Models.User;

namespace Computer_club.WebAPI.Endpoints.ClubAction.GameClubAction.Create;

public class CreateClub : EndpointBaseAsync
    .WithRequest<CreateClubCommand>
    .WithActionResult<CreateClubResult>
{
    private readonly IClubService<GameClub> _service;
    private readonly IMapper _mapper;

    public CreateClub(IClubService<GameClub> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPost("api/clubs")]
    [SwaggerOperation(
        Summary = "Club create",
        Description = "Club create",
        OperationId = "Club.Create",
        Tags = new[] { "ClubsEndpoints" })
    ]
    public override async Task<ActionResult<CreateClubResult>> HandleAsync
        ([FromBody]CreateClubCommand club, CancellationToken token = default)
    {
        var gameClub = _mapper.Map<GameClub>(club);
        var request = await _service.AddAsync(gameClub);
        var result = _mapper.Map<CreateClubResult>(request);
        return Created("", result);
    }
}