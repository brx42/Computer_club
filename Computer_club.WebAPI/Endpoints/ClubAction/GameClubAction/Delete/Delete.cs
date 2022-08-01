using Computer_club.Data.Entities.ClubEntities;
using Computer_club.Services.Services.ClubServices.ClubService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.GameClubAction.Delete;

public class Delete : EndpointBaseAsync.
        WithRequest<GameClub>.
        WithActionResult
{
    private readonly IClubService<GameClub> _service;

    public Delete(IClubService<GameClub> service)
    {
        _service = service;
    }

    [HttpDelete("api/club")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Club delete ",
        Description = "Club delete",
        OperationId = "Club.delete",
        Tags = new[] { "ClubEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(GameClub club, CancellationToken token = default)
    {
        var address = await _service.GetByIdAsync(club.Id);
        if (address == null) return NotFound();
        var result = _service.DeleteAsync(address);
        return Ok(result);
    }
}