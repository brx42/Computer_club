﻿using Computer_club.Data.Models.ClubModels;
using Computer_club.Domain.Repositories.BaseClubRepository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.PhotoAction.GetById;

public class GetByIdPhoto : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<GetByIdPhotoResult>
{
    private readonly IBaseClubRepository<Photo> _service;
    private readonly IMapper _mapper;

    public GetByIdPhoto(IBaseClubRepository<Photo> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("api/clubs/photos/{id}")]
    [SwaggerOperation(
        Summary = "Photo get",
        Description = "Photo get",
        OperationId = "Photo.GetById",
        Tags = new[] { "PhotosEndpoints" })
    ]
    public override async Task<ActionResult<GetByIdPhotoResult>> HandleAsync(int id, CancellationToken token = default)
    {
        var result = await _service.GetByIdAsync(id);
        var map = _mapper.Map<GetByIdPhotoResult>(result);
        return Ok(map);
    }
}