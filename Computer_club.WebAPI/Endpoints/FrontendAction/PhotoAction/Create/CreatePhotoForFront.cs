using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.ClubServices.PhotoService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.PhotoAction.Create;

public class CreatePhotoForFront : EndpointBaseAsync
    .WithRequest<CreatePhotoForFrontCommand>
    .WithActionResult<CreatePhotoForFrontResult>
{
    private readonly IPhotoService<Photo> _service;
    private readonly IMapper _mapper;

    public CreatePhotoForFront(IPhotoService<Photo> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPost("clubs/photos")]
    [SwaggerOperation(
        Summary = "Photo create",
        Description = "Photo create",
        OperationId = "Photo.Create",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult<CreatePhotoForFrontResult>> HandleAsync
        ([FromBody]CreatePhotoForFrontCommand request, CancellationToken token = default)
    {
        var photo = _mapper.Map<Photo>(request);
        var result = await _service.AddAsync(photo, token);
        var map = _mapper.Map<CreatePhotoForFrontResult>(result);
        return Created("", map);
    }
}