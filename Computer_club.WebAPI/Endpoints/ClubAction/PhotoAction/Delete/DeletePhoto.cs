using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.User;
using Computer_club.Services.Services.ClubServices.PhotoService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.PhotoAction.Delete;

public class DeletePhoto : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult
{
    private readonly IPhotoService<Photo> _service;

    public DeletePhoto(IPhotoService<Photo> service)
    {
        _service = service;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpDelete("api/clubs/photos/{id}")]
    [SwaggerOperation(
        Summary = "Photo delete ",
        Description = "Photo delete",
        OperationId = "Photo.delete",
        Tags = new[] { "PhotosEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(int id, CancellationToken token = default)
    {
        var find = await _service.GetByIdAsync(id);
        if (find == null) return NotFound();
        var result = _service.DeleteAsync(find, token);
        return Ok(result);
    }
}