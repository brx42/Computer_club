using Computer_club.Data.Models.ClubModels;
using Computer_club.Domain.Options;
using Computer_club.Domain.Services.ClubServices.PlaceService;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.PlaceAction.GetAllSimple;

public class GetAllSimplePlacesForFront : EndpointBaseAsync
    .WithRequest<Pagination>
    .WithActionResult
{
    private readonly IPlaceService<Place> _service;
    private readonly IMapper _mapper;

    public GetAllSimplePlacesForFront(IPlaceService<Place> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("api/clubs/simple_places")]
    [SwaggerOperation(
        Summary = "Simple places get all",
        Description = "Simple places get all",
        OperationId = "PlaceSimple.GetAll",
        Tags = new[] { "PlacesEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync([FromQuery]Pagination pagination, CancellationToken token = default)
    {
        var result = await _service.GetAllSimpleSeatsAsync(pagination, token);
        var map = _mapper.Map<List<GetAllSimplePlacesResult>>(result);
        return Ok(map);
    }
}