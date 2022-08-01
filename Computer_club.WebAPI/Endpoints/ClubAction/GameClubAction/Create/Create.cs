using Computer_club.Services.Services.ClubServices.ClubService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Computer_club.Data.Entities.ClubEntities;

namespace Computer_club.WebAPI.Endpoints.ClubAction.GameClubAction.Create;

public class Create : EndpointBaseAsync.
        WithRequest<GameClub>.
        WithActionResult<GameClub>
{
    private readonly IClubService<GameClub> _service;

    public Create(IClubService<GameClub> service)
    {
        _service = service;
    }

    [HttpPost("api/club")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Club create",
        Description = "Club create",
        OperationId = "Club.Create",
        Tags = new[] { "ClubEndpoints" })
    ]
    public override async Task<ActionResult<GameClub>> HandleAsync
        (GameClub club, CancellationToken token = default)
    {
        var result = await _service.AddAsync(club);
        return Created("", result);
    }
}