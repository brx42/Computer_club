using Computer_club.Data.Entities.Club;
using Computer_club.Services.Services.ClubServices.ClubService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.ClubAction.Delete;

public class Delete : EndpointBaseAsync.
        WithRequest<Club>.
        WithActionResult
{
    private readonly IClubService<Club> _service;

    public Delete(IClubService<Club> service)
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
    public override async Task<ActionResult> HandleAsync(Club club, CancellationToken token = default)
    {
        var address = await _service.GetByIdAsync(club.ClubId);
        if (address == null) return NotFound();
        var result = _service.DeleteAsync(address);
        return Ok(result);
    }
}