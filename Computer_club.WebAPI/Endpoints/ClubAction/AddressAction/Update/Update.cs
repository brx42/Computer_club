using Computer_club.Data.Models.Club;
using Computer_club.Services.Services.ClubServices.AddressService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.AddressAction.Update;

public class Update : EndpointBaseAsync.WithRequest<UpdateAddressCommand>.WithActionResult<UpdateAddressResult>
{
    private readonly IAddressService<AddressClub> _service;
    private readonly IMapper _mapper;

    public Update(IAddressService<AddressClub> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPut("api/club/address")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Club address update ",
        Description = "Address update",
        OperationId = "Address.Update",
        Tags = new[] { "AddressEndpoints" })
    ]
    public override async Task<ActionResult<UpdateAddressResult>> HandleAsync
        ([FromBody]UpdateAddressCommand club, CancellationToken token = default)
    {
        var address = await _service.GetByIdAsync(club.Id);
        if (address == null) return NotFound();
        _mapper.Map(club, address);
        await _service.UpdateAsync(address, token);
        var result = _mapper.Map<UpdateAddressResult>(address);
        return Ok(result);
    }
}