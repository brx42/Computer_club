using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Services.ClubServices.PhotoService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.PhotoAction.GetById;

public class GetByIdPhoto : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<GetByIdPhotoResult>
{
    private readonly IPhotoService<Photo> _service;
    private readonly IMapper _mapper;

    public GetByIdPhoto(IPhotoService<Photo> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("api/club/photo/{id}")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Photo get",
        Description = "Photo get",
        OperationId = "Photo.GetById",
        Tags = new[] { "PhotoClubEndpoints" })
    ]
    public override async Task<ActionResult<GetByIdPhotoResult>> HandleAsync(int id, CancellationToken token = default)
    {
        var result = await _service.GetByIdAsync(id);
        var map = _mapper.Map<GetByIdPhotoResult>(result);
        return Ok(map);
    }
}