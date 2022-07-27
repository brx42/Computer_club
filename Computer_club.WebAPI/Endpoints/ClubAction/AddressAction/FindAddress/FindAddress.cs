using Computer_club.Data.Entities.Club;
using Computer_club.Data.Models.Club;
using Computer_club.Services.Services.ClubServices.AddressService;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.AddressAction.FindAddress;

public class FindAddress : EndpointBaseAsync.WithRequest<FindAddressCommand>.WithActionResult<IEnumerable<string>>
{
    private readonly IAddressService<AddressClub> _address;

    public FindAddress(IAddressService<AddressClub> address)
    {
        _address = address;
    }

    [HttpPost("api/club/find_address")]
    [SwaggerOperation(
        Summary = "Club address search ",
        Description = "Address search",
        OperationId = "Address.Find",
        Tags = new[] { "AddressEndpoints" })
    ]
    public override async Task<ActionResult<IEnumerable<string>>> HandleAsync(FindAddressCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _address.FindAddressAsync(request.Address);
        return Ok(result);
    }
}