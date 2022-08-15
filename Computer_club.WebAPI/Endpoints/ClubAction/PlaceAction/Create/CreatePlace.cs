using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Domain.Repositories.BaseClubRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.PlaceAction.Create;

public class CreatePlace : EndpointBaseAsync
    .WithRequest<CreatePlaceCommand>
    .WithActionResult<CreatePlaceResult>
{
    private readonly IBaseClubRepository<Place> _service;
    private readonly IMapper _mapper;

    public CreatePlace(IBaseClubRepository<Place> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPost("api/clubs/places")]
    [SwaggerOperation(
        Summary = "Place create",
        Description = "Place create",
        OperationId = "Place.Create",
        Tags = new[] { "PlacesEndpoints" })
    ]
    public override async Task<ActionResult<CreatePlaceResult>> HandleAsync
        ([FromBody]CreatePlaceCommand request, CancellationToken token = default)
    {
        var place = _mapper.Map<Place>(request);
        var result = await _service.AddAsync(place, token);
        var map = _mapper.Map<CreatePlaceResult>(result);
        return Created("", map);
    }
}