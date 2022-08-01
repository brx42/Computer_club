using Computer_club.Data.Entities.ClubEntities;
using Computer_club.Services.Services.ClubServices.ClubService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.GameClubAction.GetById;

public class GetById : EndpointBaseAsync.WithRequest<int>.WithActionResult<GameClub>
{
    private readonly IClubService<GameClub> _service;

    public GetById(IClubService<GameClub> service)
    {
        _service = service;
    }

    [HttpGet("api/club/{id}")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Club get",
        Description = "Club get",
        OperationId = "Club.GetById",
        Tags = new[] { "ClubEndpoints" })
    ]
    public override async Task<ActionResult<GameClub>> HandleAsync(int id, CancellationToken token = default)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }
}