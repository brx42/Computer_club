using Computer_club.Data.Models.ClubModels;
using Computer_club.Domain.Options;
using Computer_club.Domain.Services.ClubServices.PlaceService;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.PlaceAction.GetAllVip;

public class GetAllVipPlaces : EndpointBaseAsync
    .WithRequest<Pagination>
    .WithActionResult
{
    private readonly IPlaceService<Place> _service;
    private readonly IMapper _mapper;

    public GetAllVipPlaces(IPlaceService<Place> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("api/clubs/vip_places")]
    [SwaggerOperation(
        Summary = "Vip places get all",
        Description = "Vip places get all",
        OperationId = "PlaceVip.GetAll",
        Tags = new[] { "PlacesEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync([FromQuery]Pagination pagination, CancellationToken token = default)
    {
        var result = await _service.GetAllVipSeatsAsync(pagination, token);
        var map = _mapper.Map<List<GetAllVipPlacesResult>>(result);
        return Ok(map);
    }
}