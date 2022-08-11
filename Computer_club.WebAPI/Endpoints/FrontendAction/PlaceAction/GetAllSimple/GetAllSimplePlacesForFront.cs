using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Options;
using Computer_club.Services.Services.ClubServices.PlaceService;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.PlaceAction.GetAllSimple;

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

    [HttpGet("clubs/simple_places")]
    [SwaggerOperation(
        Summary = "Simple places get all",
        Description = "Simple places get all",
        OperationId = "PlaceSimple.GetAll",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync([FromQuery]Pagination request, CancellationToken token = default)
    {
        var result = await _service.GetAllSimpleSeatsAsync(request, token);
        var map = _mapper.Map<List<GetAllSimplePlacesForFrontResult>>(result);
        return Ok(map);
    }
}