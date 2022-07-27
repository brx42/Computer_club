using Computer_club.Data.Models.Club;
using Computer_club.Services.Services.ClubServices.DescriptionServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.DescriptionAction.GetAll;

public class GetAll : EndpointBaseAsync.
    WithoutRequest.
    WithActionResult
{
    private readonly IDescriptionService<DescriptionClub> _service;

    public GetAll(IDescriptionService<DescriptionClub> service)
    {
        _service = service;
    }

    [HttpGet("api/club/description")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Club description get all",
        Description = "Description get all",
        OperationId = "Description.GetAll",
        Tags = new[] { "DescriptionEndpoints" })
    ]

public override async Task<ActionResult> HandleAsync(CancellationToken token = default)
    {
        var result = await _service.GetAllAsync(token);
        return Ok(result);
    }
}