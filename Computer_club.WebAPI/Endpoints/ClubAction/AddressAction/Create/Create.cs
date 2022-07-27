using Computer_club.Data.Models.Club;
using Computer_club.Services.Services.ClubServices.AddressService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.AddressAction.Create;

public class Create : EndpointBaseAsync.
        WithRequest<AddressClub>.
        WithActionResult<AddressClub>
{
    private readonly IAddressService<AddressClub> _service;

    public Create(IAddressService<AddressClub> service)
    {
        _service = service;
    }

    [HttpPost("api/club/address")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Club address create ",
        Description = "Address create",
        OperationId = "Address.Create",
        Tags = new[] { "AddressEndpoints" })
    ]
    public override async Task<ActionResult<AddressClub>> HandleAsync
        (AddressClub club, CancellationToken token = default)
    {
        var result = await _service.AddAsync(club);
        return Created("", result);
    }
}