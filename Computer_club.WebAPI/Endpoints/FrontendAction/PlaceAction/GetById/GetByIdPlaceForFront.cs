using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Services.ClubServices.PlaceService;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.PlaceAction.GetById;

public class GetByIdPlaceForFront : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<GetByIdPlaceForFrontResult>
{
    private readonly IPlaceService<Place> _service;
    private readonly IMapper _mapper;

    public GetByIdPlaceForFront(IPlaceService<Place> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("clubs/places/{id}")]
    [SwaggerOperation(
        Summary = "Place get",
        Description = "Place get",
        OperationId = "Place.GetById",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult<GetByIdPlaceForFrontResult>> HandleAsync(int id, CancellationToken token = default)
    {
        var result = await _service.GetByIdAsync(id);
        var map = _mapper.Map<GetByIdPlaceForFrontResult>(result);
        return Ok(map);
    }
}