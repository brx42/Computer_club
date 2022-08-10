using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Services.ClubServices.PlaceService;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.BackendAction.ClubAction.PlaceAction.GetById;

public class GetByIdPlace : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<GetByIdPlaceResult>
{
    private readonly IPlaceService<Place> _service;
    private readonly IMapper _mapper;

    public GetByIdPlace(IPlaceService<Place> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("api/clubs/places/{id}")]
    [SwaggerOperation(
        Summary = "Place get",
        Description = "Place get",
        OperationId = "Place.GetById",
        Tags = new[] { "PlacesEndpoints" })
    ]
    public override async Task<ActionResult<GetByIdPlaceResult>> HandleAsync(int id, CancellationToken token = default)
    {
        var result = await _service.GetByIdAsync(id);
        var map = _mapper.Map<GetByIdPlaceResult>(result);
        return Ok(map);
    }
}