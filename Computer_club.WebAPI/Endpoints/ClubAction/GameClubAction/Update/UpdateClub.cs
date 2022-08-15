using Computer_club.Data.Entities.ClubEntities;
using Computer_club.Data.Models.UserModels;
using Computer_club.Domain.Repositories.BaseClubRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.GameClubAction.Update;

public class UpdateClub : EndpointBaseAsync
    .WithRequest<UpdateClubCommand>
    .WithActionResult<UpdateClubResult>
{
    private readonly IBaseClubRepository<GameClub> _service;
    private readonly IMapper _mapper;

    public UpdateClub(IBaseClubRepository<GameClub> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPut("api/clubs")]
    [SwaggerOperation(
        Summary = "Club update",
        Description = "Club update",
        OperationId = "Club.Update",
        Tags = new[] { "ClubsEndpoints" })
    ]
    public override async Task<ActionResult<UpdateClubResult>> HandleAsync
        ([FromBody]UpdateClubCommand club, CancellationToken token = default)
    {
        var find = await _service.GetByIdAsync(club.Id);
        if (find == null) return NotFound();
        _mapper.Map(club, find);
        await _service.UpdateAsync(find, token);
        var result = _mapper.Map<UpdateClubResult>(find);
        return Ok(result);
    }
}