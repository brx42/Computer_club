using Computer_club.Data.Models.Club;
using Computer_club.Services.Services.ClubServices.DescriptionServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.DescriptionAction.Update;

public class Update : EndpointBaseAsync.
        WithRequest<UpdateDescriptionCommand>.
        WithActionResult<UpdateDescriptionResult>
{
    private readonly IDescriptionService<DescriptionClub> _service;
    private readonly IMapper _mapper;

    public Update(IDescriptionService<DescriptionClub> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPut("api/club/description")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Club description update ",
        Description = "Description update",
        OperationId = "Description.Update",
        Tags = new[] { "DescriptionEndpoints" })
    ]
    public override async Task<ActionResult<UpdateDescriptionResult>> HandleAsync
        (UpdateDescriptionCommand description, CancellationToken token = default)
    {
        var desc = await _service.GetByIdAsync(description.Id);
        if (desc == null) return NotFound();
        _mapper.Map(description, desc);
        await _service.UpdateAsync(desc, token);
        var result = _mapper.Map<UpdateDescriptionResult>(desc);
        return Ok(result);
    }
}