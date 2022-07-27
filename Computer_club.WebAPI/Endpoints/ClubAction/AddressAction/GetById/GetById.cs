using Computer_club.Data.Models.Club;
using Computer_club.Services.Services.ClubServices.AddressService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.AddressAction.GetById;

public class GetById : EndpointBaseAsync.WithRequest<Guid>.WithActionResult<AddressClub>
{
    private readonly IAddressService<AddressClub> _service;

    public GetById(IAddressService<AddressClub> service)
    {
        _service = service;
    }

    [HttpGet("api/club/address/{id}")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Club address get ",
        Description = "Address get",
        OperationId = "Address.GetById",
        Tags = new[] { "AddressEndpoints" })
    ]
    public override async Task<ActionResult<AddressClub>> HandleAsync(Guid id, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }
}