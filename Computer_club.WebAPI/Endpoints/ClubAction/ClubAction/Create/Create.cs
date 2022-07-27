using Computer_club.Data.Entities.Club;
using Computer_club.Services.Services.ClubServices.ClubService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.ClubAction.Create;

public class Create : EndpointBaseAsync.
        WithRequest<Club>.
        WithActionResult<Club>
{
    private readonly IClubService<Club> _service;

    public Create(IClubService<Club> service)
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
    public override async Task<ActionResult<Club>> HandleAsync
        (Club club, CancellationToken token = default)
    {
        var result = await _service.AddAsync(club);
        return Created("", result);
    }
}