using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Services.ClubServices.DeviceSetService;
using Computer_club.Services.Services.ClubServices.PlaceService;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.PlaceAction.GetAllFreePlacesEveryTypeForFront;

public class GetAllFreePlacesEveryTypeForFront : EndpointBaseAsync
    .WithRequest<GetAllFreePlacesEveryTypeForFrontCommand>
    .WithActionResult
{
    private readonly IPlaceService<Place> _place;
    private readonly IDeviceSetService<DeviceSet> _device;
    private readonly IMapper _mapper;

    public GetAllFreePlacesEveryTypeForFront(IPlaceService<Place> place, IDeviceSetService<DeviceSet> device, IMapper mapper)
    {
        _place = place;
        _device = device;
        _mapper = mapper;
    }

    [HttpGet("clubs/free_places_every_type")]
    [SwaggerOperation(
        Summary = "Free places every type get all",
        Description = "Free places every type get all",
        OperationId = "PlaceFreeEveryType.GetAll",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync
    ([FromQuery]GetAllFreePlacesEveryTypeForFrontCommand request, CancellationToken token = default)
    {
        GetAllFreePlacesEveryTypeForFrontResult places = new();
        List<Place> free = await _place.GetAllFreePlacesForTypeAsync(request.PageNumber, request.PageSize, request.NameSet);
        List<PlaceNotReal> mapFree = _mapper.Map<List<PlaceNotReal>>(free);

        places.DeviceSet = request.NameSet;
        places.Places = mapFree;
        return Ok(places);
    }
}