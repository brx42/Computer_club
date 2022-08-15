using Computer_club.Data.Models.ClubModels;
using Computer_club.Domain.Options;
using Computer_club.Domain.Services.ClubServices.PlaceService;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.PlaceAction.GetAllBusy;

public class GetAllBusyPlaces : EndpointBaseAsync
    .WithRequest<Pagination>
    .WithActionResult
{
    private readonly IPlaceService<Place> _place;
    private readonly IMapper _mapper;

    public GetAllBusyPlaces(IMapper mapper, IPlaceService<Place> place)
    {
        _mapper = mapper;
        _place = place;
    }

    [HttpGet("api/clubs/busy_places")]
    [SwaggerOperation(
        Summary = "Busy places get all",
        Description = "Busy places get all",
        OperationId = "PlaceBusy.GetAll",
        Tags = new[] { "PlacesEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync([FromQuery]Pagination pagination, CancellationToken token = default)
    {
        var result = await _place.GetAllBusySeatsAsync(pagination, token);
        var map = _mapper.Map<List<GetAllBusyPlacesResult>>(result);
        return Ok(map);
    }
}