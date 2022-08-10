using Computer_club.Data.Entities.ClubEntities;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.ClubServices.ClubService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.ClubAction.Create;

public class CreateClubForFront : EndpointBaseAsync
    .WithRequest<CreateClubForFrontCommand>
    .WithActionResult<CreateClubForFrontResult>
{
    private readonly IClubService<GameClub> _service;
    private readonly IMapper _mapper;

    public CreateClubForFront(IClubService<GameClub> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPost("clubs")]
    [SwaggerOperation(
        Summary = "Club create",
        Description = "Club create",
        OperationId = "Club.Create",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult<CreateClubForFrontResult>> HandleAsync
        ([FromBody]CreateClubForFrontCommand club, CancellationToken token = default)
    {
        var gameClub = _mapper.Map<GameClub>(club);
        var request = await _service.AddAsync(gameClub);
        var result = _mapper.Map<CreateClubForFrontResult>(request);
        return Created("", result);
    }
}