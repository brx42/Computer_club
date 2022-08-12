using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Options;
using Computer_club.Services.Services.ClubServices.PlaceService;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.PlaceAction.GetAllFree;

public class GetAllFreePlacesForFront : EndpointBaseAsync
    .WithRequest<IPagination>
    .WithActionResult
{
    private readonly IPlaceService<Place> _service;
    private readonly IMapper _mapper;

    public GetAllFreePlacesForFront(IPlaceService<Place> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("clubs/free_places")]
    [SwaggerOperation(
        Summary = "Free places get all",
        Description = "Free places get all",
        OperationId = "PlaceFree.GetAll",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync([FromQuery]IPagination pagination, CancellationToken token = default)
    {
        var result = await _service.GetAllFreeSeatsAsync(pagination.PageNumber, pagination.PageSize, token);
        var map = _mapper.Map<List<GetAllFreePlacesForFrontResult>>(result);
        return Ok(map);
    }
}