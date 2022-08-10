using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.ClubServices.ScheduleService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.ScheduleAction.Update;

public class UpdateScheduleForFront : EndpointBaseAsync
    .WithRequest<UpdateScheduleForFrontCommand>
    .WithActionResult<UpdateScheduleForFrontResult>
{
    private readonly IScheduleService<Schedule> _service;
    private readonly IMapper _mapper;

    public UpdateScheduleForFront(IScheduleService<Schedule> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPut("clubs/schedules")]
    [SwaggerOperation(
        Summary = "Schedules update",
        Description = "Schedules update",
        OperationId = "Schedules.Update",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult<UpdateScheduleForFrontResult>> HandleAsync
        ([FromBody]UpdateScheduleForFrontCommand request, CancellationToken token = default)
    {
        var find = await _service.GetByIdAsync(request.Id);
        if (find == null) return NotFound();
        _mapper.Map(request, find);
        await _service.UpdateAsync(find, token);
        var result = _mapper.Map<UpdateScheduleForFrontResult>(find);
        return Ok(result);
    }
}