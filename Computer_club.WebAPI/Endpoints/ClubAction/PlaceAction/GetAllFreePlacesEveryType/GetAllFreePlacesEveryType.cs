using Computer_club.Data.Models.ClubModels;
using Computer_club.Domain.Options;
using Computer_club.Domain.Services.ClubServices.PlaceService;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.PlaceAction.GetAllFreePlacesEveryType;

public class GetAllFreePlacesEveryType : EndpointBaseAsync
    .WithRequest<GetAllFreePlacesEveryTypeCommand>
    .WithActionResult
{
    private readonly IPlaceService<Place> _place;
    private readonly IMapper _mapper;

    public GetAllFreePlacesEveryType(IPlaceService<Place> place, IMapper mapper)
    {
        _place = place;
        _mapper = mapper;
    }

    [HttpGet("api/clubs/free_places_every_type")]
    [SwaggerOperation(
        Summary = "Free places every type get all",
        Description = "Free places every type get all",
        OperationId = "PlaceFreeEveryType.GetAll",
        Tags = new[] { "PlacesEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync
    ([FromQuery]GetAllFreePlacesEveryTypeCommand request, CancellationToken token = default)
    {
        GetAllFreePlacesEveryTypeResult places = new();
        Pagination pagination = new(request.PageNumber, request.PageSize);
        List<Place> free = await _place.GetAllFreePlacesForTypeAsync(pagination, request.NameSet);
        List<PlaceNotReal> mapFree = _mapper.Map<List<PlaceNotReal>>(free);

        places.DeviceSet = request.NameSet;
        places.Places = mapFree;
        return Ok(places);
    }
}