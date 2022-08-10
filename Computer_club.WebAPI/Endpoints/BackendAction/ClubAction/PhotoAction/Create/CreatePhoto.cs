using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.ClubServices.PhotoService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.BackendAction.ClubAction.PhotoAction.Create;

public class CreatePhoto : EndpointBaseAsync
    .WithRequest<CreatePhotoCommand>
    .WithActionResult<CreatePhotoResult>
{
    private readonly IPhotoService<Photo> _service;
    private readonly IMapper _mapper;

    public CreatePhoto(IPhotoService<Photo> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPost("api/clubs/photos")]
    [SwaggerOperation(
        Summary = "Photo create",
        Description = "Photo create",
        OperationId = "Photo.Create",
        Tags = new[] { "PhotosEndpoints" })
    ]
    public override async Task<ActionResult<CreatePhotoResult>> HandleAsync
        ([FromBody]CreatePhotoCommand request, CancellationToken token = default)
    {
        var photo = _mapper.Map<Photo>(request);
        var result = await _service.AddAsync(photo, token);
        var map = _mapper.Map<CreatePhotoResult>(result);
        return Created("", map);
    }
}