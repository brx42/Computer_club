using Computer_club.Data.Entities.Club;
using Computer_club.Data.Models.Club;
using Computer_club.Services.Services.ClubServices.AddressService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.AddressAction.GetAll;

public class GetAll : EndpointBaseAsync.WithoutRequest.WithActionResult
{
    private readonly IAddressService<AddressClub> _service;

    public GetAll(IAddressService<AddressClub> service)
    {
        _service = service;
    }

    [HttpGet("api/club/address")]
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