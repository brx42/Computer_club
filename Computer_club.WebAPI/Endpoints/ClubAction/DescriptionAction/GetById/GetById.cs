using Computer_club.Data.Models.Club;
using Computer_club.Services.Services.ClubServices.DescriptionServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.DescriptionAction.GetById;

public class GetById : EndpointBaseAsync.
        WithRequest<Guid>.
        WithActionResult<DescriptionClub>
{
    private readonly IDescriptionService<DescriptionClub> _service;

    public GetById(IDescriptionService<DescriptionClub> service)
    {
        _service = service;
    }

    [HttpGet("api/club/description/{id}")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Club description get ",
        Description = "Description get",
        OperationId = "Description.GetById",
        Tags = new[] { "DescriptionEndpoints" })
    ]
    public override async Task<ActionResult<DescriptionClub>> HandleAsync(Guid id, CancellationToken token = default)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }
}