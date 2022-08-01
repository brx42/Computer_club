using Computer_club.Data.Entities.ClubEntities;
using Computer_club.Services.Services.ClubServices.ClubService;
using Computer_club.WebAPI.Endpoints.ClubAction.ClubAction.FindAddress;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.GameClubAction.FindAddress;

public class FindAddress : EndpointBaseAsync.WithRequest<FindAddressCommand>.WithActionResult<IEnumerable<string>>
{
    private readonly IClubService<GameClub> _address;

    public FindAddress(IClubService<GameClub> address)
    {
        _address = address;
    }

    [HttpPost("api/club/find_address")]
    [SwaggerOperation(
        Summary = "Club address search ",
        Description = "Address search",
        OperationId = "Address.Find",
        Tags = new[] { "ClubEndpoints" })
    ]
    public override async Task<ActionResult<IEnumerable<string>>> HandleAsync(FindAddressCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _address.FindAddressAsync(request.Address);
        return Ok(result);
    }
}