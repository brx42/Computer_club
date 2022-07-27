using Computer_club.Data.Models.Club;
using Computer_club.Services.Services.ClubServices.AddressService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.AddressAction.Delete;

public class Delete : EndpointBaseAsync.WithRequest<AddressClub>.WithActionResult
{
    private readonly IAddressService<AddressClub> _service;

    public Delete(IAddressService<AddressClub> service)
    {
        _service = service;
    }

    [HttpDelete("api/club/address")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Club address delete ",
        Description = "Address delete",
        OperationId = "Address.delete",
        Tags = new[] { "AddressEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(AddressClub club, CancellationToken cancellationToken = new CancellationToken())
    {
        var address = await _service.GetByIdAsync(club.Id);
        if (address == null) return NotFound();
        var result = _service.DeleteAsync(address);
        return Ok(result);
    }
}