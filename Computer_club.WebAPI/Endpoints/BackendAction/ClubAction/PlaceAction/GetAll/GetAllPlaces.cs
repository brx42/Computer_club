using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Options;
using Computer_club.Services.Services.ClubServices.PlaceService;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.BackendAction.ClubAction.PlaceAction.GetAll;

public class GetAllPlaces : EndpointBaseAsync
    .WithRequest<Pagination>
    .WithActionResult
{
    private readonly IPlaceService<Place> _service;
    private readonly IMapper _mapper;

    public GetAllPlaces(IPlaceService<Place> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("api/clubs/places")]
    [SwaggerOperation(
        Summary = "Places get all",
        Description = "Places get all",
        OperationId = "Place.GetAll",
        Tags = new[] { "PlacesEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync([FromQuery]Pagination pagination, CancellationToken token = default)
    {
        var result = await _service.GetAllAsync(pagination, token);
        var map = _mapper.Map<List<GetAllPlacesResult>>(result);
        return Ok(map);
    }
}