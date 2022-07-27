using Computer_club.Data.Entities.Club;
using Computer_club.Services.Services.ClubServices.ClubService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.ClubAction.GetAll;

public class GetAll : EndpointBaseAsync.WithoutRequest.WithActionResult
{
    private readonly IClubService<Club> _service;

    public GetAll(IClubService<Club> service)
    {
        _service = service;
    }

    [HttpGet("api/club")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Club address get all",
        Description = "Address get all",
        OperationId = "Address.GetAll",
        Tags = new[] { "AddressEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(CancellationToken token = default)
    {
        var result = await _service.GetAllAsync(token);
        return Ok(result);
    }
}