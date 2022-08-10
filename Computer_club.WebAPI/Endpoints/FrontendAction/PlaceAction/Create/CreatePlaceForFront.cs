using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.ClubServices.PlaceService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.PlaceAction.Create;

public class CreatePlaceForFront : EndpointBaseAsync
    .WithRequest<CreatePlaceForFrontCommand>
    .WithActionResult<CreatePlaceForFrontResult>
{
    private readonly IPlaceService<Place> _service;
    private readonly IMapper _mapper;

    public CreatePlaceForFront(IPlaceService<Place> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPost("clubs/places")]
    [SwaggerOperation(
        Summary = "Place create",
        Description = "Place create",
        OperationId = "Place.Create",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult<CreatePlaceForFrontResult>> HandleAsync
        ([FromBody]CreatePlaceForFrontCommand request, CancellationToken token = default)
    {
        var place = _mapper.Map<Place>(request);
        var result = await _service.AddAsync(place, token);
        var map = _mapper.Map<CreatePlaceForFrontResult>(result);
        return Created("", map);
    }
}