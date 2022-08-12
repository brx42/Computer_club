using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Options;
using Computer_club.Services.Services.ClubServices.PlaceService;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.PlaceAction.GetAllBusy;

public class GetAllBusyPlacesForFront : EndpointBaseAsync
    .WithRequest<IPagination>
    .WithActionResult
{
    private readonly IPlaceService<Place> _service;
    private readonly IMapper _mapper;

    public GetAllBusyPlacesForFront(IPlaceService<Place> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("clubs/busy_places")]
    [SwaggerOperation(
        Summary = "Busy places get all",
        Description = "Busy places get all",
        OperationId = "PlaceBusy.GetAll",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync([FromQuery]IPagination pagination, CancellationToken token = default)
    {
        var result = await _service.GetAllBusySeatsAsync(pagination.PageNumber, pagination.PageSize, token);
        var map = _mapper.Map<List<GetAllBusyPlacesForFrontResult>>(result);
        return Ok(map);
    }
}