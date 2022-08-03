using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.User;
using Computer_club.Services.Services.ClubServices.PlaceService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.PlaceAction.Delete;

public class DeletePlace : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult
{
    private readonly IPlaceService<Place> _service;

    public DeletePlace(IPlaceService<Place> service)
    {
        _service = service;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpDelete("api/clubs/places/{id}")]
    [SwaggerOperation(
        Summary = "Place delete ",
        Description = "Place delete",
        OperationId = "Place.delete",
        Tags = new[] { "PlacesEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(int id, CancellationToken token = default)
    {
        var find = await _service.GetByIdAsync(id);
        if (find == null) return NotFound();
        var result = _service.DeleteAsync(find, token);
        return Ok(result);
    }
}