using Computer_club.Data.Entities;
using Computer_club.Data.Models.UserModels;
using Computer_club.Domain.Repositories.BaseClubRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.GameClubAction.Delete;

public class DeleteClub : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult
{
    private readonly IBaseClubRepository<GameClub> _service;

    public DeleteClub(IBaseClubRepository<GameClub> service)
    {
        _service = service;
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
        var result = _service.DeleteAsync(club, token);
        return Ok(result);
    }
}