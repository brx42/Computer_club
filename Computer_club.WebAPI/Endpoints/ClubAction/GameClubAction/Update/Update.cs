using Computer_club.Data.Entities.ClubEntities;
using Computer_club.Services.Services.ClubServices.ClubService;
using Computer_club.WebAPI.Endpoints.ClubAction.ClubAction.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.GameClubAction.Update;

public class Update : EndpointBaseAsync.WithRequest<UpdateClubCommand>.WithActionResult<UpdateClubResult>
{
    private readonly IClubService<GameClub> _service;
    private readonly IMapper _mapper;

    public Update(IClubService<GameClub> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPut("api/club")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Club update",
        Description = "Club update",
        OperationId = "Club.Update",
        Tags = new[] { "ClubEndpoints" })
    ]
    public override async Task<ActionResult<UpdateClubResult>> HandleAsync
        ([FromBody]UpdateClubCommand club, CancellationToken token = default)
    {
        var address = await _service.GetByIdAsync(club.Id);
        if (address == null) return NotFound();
        _mapper.Map(club, address);
        await _service.UpdateAsync(address, token);
        var result = _mapper.Map<UpdateClubResult>(address);
        return Ok(result);
    }
}