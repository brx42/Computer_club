﻿using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Services.ClubServices.PlaceService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.PlaceAction.Create;

public class CreatePlace : EndpointBaseAsync
    .WithRequest<CreatePlaceCommand>
    .WithActionResult<CreatePlaceResult>
{
    private readonly IPlaceService<Place> _service;
    private readonly IMapper _mapper;

    public CreatePlace(IPlaceService<Place> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost("api/club/place")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Place create",
        Description = "Place create",
        OperationId = "Place.Create",
        Tags = new[] { "PlaceEndpoints" })
    ]
    public override async Task<ActionResult<CreatePlaceResult>> HandleAsync
        ([FromBody]CreatePlaceCommand request, CancellationToken token = default)
    {
        var place = _mapper.Map<Place>(request);
        var result = await _service.AddAsync(place, token);
        var map = _mapper.Map<CreatePlaceResult>(result);
        return Created("", map);
    }
}