﻿using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Options;
using Computer_club.Services.Services.ClubServices.PhotoService;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.BackendAction.ClubAction.PhotoAction.GetAll;

public class GetAllPhotos : EndpointBaseAsync
    .WithRequest<Pagination>
    .WithActionResult
{
    private readonly IPhotoService<Photo> _service;
    private readonly IMapper _mapper;

    public GetAllPhotos(IPhotoService<Photo> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("api/clubs/photos")]
    [SwaggerOperation(
        Summary = "Photo get all",
        Description = "Photo get all",
        OperationId = "Photo.GetAll",
        Tags = new[] { "PhotosEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(Pagination pagination, CancellationToken token = default)
    {
        var result = await _service.GetAllAsync(pagination, token);
        var map = _mapper.Map<List<GetAllPhotosResult>>(result);
        return Ok(map);
    }
}