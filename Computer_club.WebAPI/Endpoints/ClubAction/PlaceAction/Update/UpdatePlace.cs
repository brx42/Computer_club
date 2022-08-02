using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Services.ClubServices.PlaceService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.PlaceAction.Update;

public class UpdatePlace : EndpointBaseAsync
    .WithRequest<UpdatePlaceCommand>
    .WithActionResult<UpdatePlaceResult>
{
    private readonly IPlaceService<Place> _service;
    private readonly IMapper _mapper;

    public UpdatePlace(IPlaceService<Place> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPut("api/club/place")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Place update",
        Description = "Place update",
        OperationId = "Place.Update",
        Tags = new[] { "PlaceEndpoints" })
    ]
    public override async Task<ActionResult<UpdatePlaceResult>> HandleAsync
        ([FromBody]UpdatePlaceCommand request, CancellationToken token = default)
    {
        var find = await _service.GetByIdAsync(request.Id);
        if (find == null) return NotFound();
        _mapper.Map(request, find);
        await _service.UpdateAsync(find, token);
        var result = _mapper.Map<UpdatePlaceResult>(find);
        return Ok(result);
    }
}