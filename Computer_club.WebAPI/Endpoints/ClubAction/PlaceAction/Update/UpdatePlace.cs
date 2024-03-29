﻿using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Domain.Repositories.BaseClubRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.PlaceAction.Update;

public class UpdatePlace : EndpointBaseAsync
    .WithRequest<UpdatePlaceCommand>
    .WithActionResult<UpdatePlaceResult>
{
    private readonly IBaseClubRepository<Place> _service;
    private readonly IMapper _mapper;

    public UpdatePlace(IBaseClubRepository<Place> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPut("api/clubs/places")]
    [SwaggerOperation(
        Summary = "Place update",
        Description = "Place update",
        OperationId = "Place.Update",
        Tags = new[] { "PlacesEndpoints" })
    ]
    public override async Task<ActionResult<UpdatePlaceResult>> HandleAsync
        ([FromBody]UpdatePlaceCommand request, CancellationToken token = default)
    {
        var find = await _service.GetByIdAsync(request.Id);
        if (find == null) return NotFound();
        _mapper.Map(request, find);
        await _service.UpdateAsync(find, token);
        var result = _mapper.Map<UpdatePlaceResult>(find);
        return Ok(result);
    }
}