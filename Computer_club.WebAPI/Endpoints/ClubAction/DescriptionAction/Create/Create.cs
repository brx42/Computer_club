using Computer_club.Data.Models.Club;
using Computer_club.Services.Services.ClubServices.DescriptionServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.DescriptionAction.Create;

public class Create : EndpointBaseAsync.
        WithRequest<DescriptionClub>.
        WithActionResult<DescriptionClub>
{
    private readonly IDescriptionService<DescriptionClub> _service;

    public Create(IDescriptionService<DescriptionClub> service)
    {
        _service = service;
    }

    [HttpPost("api/club/description")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Club description create ",
        Description = "Description create",
        OperationId = "Description.Create",
        Tags = new[] { "DescriptionEndpoints" })
    ]
    public override async Task<ActionResult<DescriptionClub>> HandleAsync
        (DescriptionClub description, CancellationToken cancellationToken = default)
    {
        var result = await _service.AddAsync(description);
        return Created("", result);
    }
}