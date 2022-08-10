using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.ClubServices.PhotoService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.PhotoAction.Delete;

public class DeletePhotoForFront : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult
{
    private readonly IPhotoService<Photo> _service;

    public DeletePhotoForFront(IPhotoService<Photo> service)
    {
        _service = service;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpDelete("clubs/photos/{id}")]
    [SwaggerOperation(
        Summary = "Photo delete ",
        Description = "Photo delete",
        OperationId = "Photo.delete",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(int id, CancellationToken token = default)
    {
        var find = await _service.GetByIdAsync(id);
        if (find == null) return NotFound();
        var result = _service.DeleteAsync(find, token);
        return Ok(result);
    }
}