using Computer_club.Data.Entities.Club;
using Computer_club.Services.Services.ClubServices.ClubService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.ClubAction.GetById;

public class GetById : EndpointBaseAsync.WithRequest<Guid>.WithActionResult<Club>
{
    private readonly IClubService<Club> _service;

    public GetById(IClubService<Club> service)
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
    public override async Task<ActionResult<Club>> HandleAsync(Guid id, CancellationToken token = default)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }
}