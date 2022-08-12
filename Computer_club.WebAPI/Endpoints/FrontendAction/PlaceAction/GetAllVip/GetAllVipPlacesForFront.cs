using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Options;
using Computer_club.Services.Services.ClubServices.PlaceService;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.PlaceAction.GetAllVip;

public class GetAllVipPlacesForFront : EndpointBaseAsync
    .WithRequest<IPagination>
    .WithActionResult
{
    private readonly IPlaceService<Place> _service;
    private readonly IMapper _mapper;

    public GetAllVipPlacesForFront(IPlaceService<Place> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("clubs/vip_places")]
    [SwaggerOperation(
        Summary = "Vip places get all",
        Description = "Vip places get all",
        OperationId = "PlaceVip.GetAll",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync([FromQuery]IPagination pagination, CancellationToken token = default)
    {
        var result = await _service.GetAllVipSeatsAsync(pagination.PageNumber, pagination.PageSize, token);
        var map = _mapper.Map<List<GetAllVipPlacesForFrontResult>>(result);
        return Ok(map);
    }
}