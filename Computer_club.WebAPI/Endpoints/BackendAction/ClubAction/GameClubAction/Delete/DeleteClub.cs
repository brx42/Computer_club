﻿using Computer_club.Data.Entities.ClubEntities;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.ClubServices.ClubService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.BackendAction.ClubAction.GameClubAction.Delete;

public class DeleteClub : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult
{
    private readonly IClubService<GameClub> _service;
    private readonly IMapper _mapper;

    public DeleteClub(IClubService<GameClub> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpDelete("api/clubs/{id}")]
    [SwaggerOperation(
        Summary = "Club delete ",
        Description = "Club delete",
        OperationId = "Club.delete",
        Tags = new[] { "ClubsEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(int id, CancellationToken token = default)
    {
        var club = await _service.GetByIdAsync(id);
        if (club == null) return NotFound();
        var result = _service.DeleteAsync(club);
        return Ok(result);
    }
}