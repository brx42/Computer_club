﻿using Computer_club.Data.Entities;
using Computer_club.Domain.Services.ClubServices.ClubService;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.GameClubAction.FindAddress;

public class FindAddress : EndpointBaseAsync
    .WithRequest<FindAddressCommand>
    .WithActionResult<IEnumerable<string>>
{
    private readonly IClubService<GameClub> _address;

    public FindAddress(IClubService<GameClub> address)
    {
        _address = address;
    }

    [HttpPost("api/clubs/find_addresses")]
    [SwaggerOperation(
        Summary = "Club address search ",
        Description = "Address search",
        OperationId = "Address.Find",
        Tags = new[] { "ClubsEndpoints" })
    ]
    public override async Task<ActionResult<IEnumerable<string>>> HandleAsync(FindAddressCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _address.FindAddressAsync(request.Address);
        return Ok(result);
    }
}