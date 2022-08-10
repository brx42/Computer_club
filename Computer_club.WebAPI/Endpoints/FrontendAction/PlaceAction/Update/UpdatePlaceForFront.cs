using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.ClubServices.PlaceService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.PlaceAction.Update;

public class UpdatePlaceForFront : EndpointBaseAsync
    .WithRequest<UpdatePlaceForFrontCommand>
    .WithActionResult<UpdatePlaceForFrontResult>
{
    private readonly IPlaceService<Place> _service;
    private readonly IMapper _mapper;

    public UpdatePlaceForFront(IPlaceService<Place> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPut("clubs/places")]
    [SwaggerOperation(
        Summary = "Place update",
        Description = "Place update",
        OperationId = "Place.Update",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult<UpdatePlaceForFrontResult>> HandleAsync
        ([FromBody]UpdatePlaceForFrontCommand request, CancellationToken token = default)
    {
        var find = await _service.GetByIdAsync(request.Id);
        if (find == null) return NotFound();
        _mapper.Map(request, find);
        await _service.UpdateAsync(find, token);
        var result = _mapper.Map<UpdatePlaceForFrontResult>(find);
        return Ok(result);
    }
}