using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.ClubServices.PhotoService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.PhotoAction.Update;

public class UpdatePhoto : EndpointBaseAsync
    .WithRequest<UpdatePhotoCommand>
    .WithActionResult<UpdatePhotoResult>
{
    private readonly IPhotoService<Photo> _service;
    private readonly IMapper _mapper;

    public UpdatePhoto(IPhotoService<Photo> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPut("api/clubs/photos")]
    [SwaggerOperation(
        Summary = "Photo update",
        Description = "Photo update",
        OperationId = "Photo.Update",
        Tags = new[] { "PhotosEndpoints" })
    ]
    public override async Task<ActionResult<UpdatePhotoResult>> HandleAsync
        ([FromBody]UpdatePhotoCommand request, CancellationToken token = default)
    {
        var find = await _service.GetByIdAsync(request.Id);
        if (find == null) return NotFound();
        _mapper.Map(request, find);
        await _service.UpdateAsync(find, token);
        var result = _mapper.Map<UpdatePhotoResult>(find);
        return Ok(result);
    }
}