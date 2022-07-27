using Computer_club.Data.Models.Club;
using Computer_club.Services.Services.ClubServices.DescriptionServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.DescriptionAction.Delete;

public class Delete : EndpointBaseAsync.
        WithRequest<DescriptionClub>.
        WithActionResult
{
    private readonly IDescriptionService<DescriptionClub> _service;

    public Delete(IDescriptionService<DescriptionClub> service)
    {
        _service = service;
    }

    [HttpDelete("api/club/description")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Club description delete ",
        Description = "Description delete",
        OperationId = "Description.delete",
        Tags = new[] { "DescriptionEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync
        (DescriptionClub description, CancellationToken token = default)
    {
        var desc = await _service.GetByIdAsync(description.Id);
        if (desc == null) return NotFound();
        var result = _service.DeleteAsync(desc, token);
        return Ok(result);
    }
}