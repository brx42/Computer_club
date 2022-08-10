using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.ClubServices.ScheduleService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.ScheduleAction.Create;

public class CreateScheduleForFront : EndpointBaseAsync
    .WithRequest<CreateScheduleForFrontCommand>
    .WithActionResult<CreateScheduleForFrontResult>
{
    private readonly IScheduleService<Schedule> _service;
    private readonly IMapper _mapper;

    public CreateScheduleForFront(IScheduleService<Schedule> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPost("clubs/schedules")]
    [SwaggerOperation(
        Summary = "Schedule create",
        Description = "Schedule create",
        OperationId = "Schedule.Create",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult<CreateScheduleForFrontResult>> HandleAsync
        ([FromBody]CreateScheduleForFrontCommand request, CancellationToken token = default)
    {
        var schedule = _mapper.Map<Schedule>(request);
        var add = await _service.AddAsync(schedule);
        var result = _mapper.Map<CreateScheduleForFrontResult>(add);
        return Created("", result);
    }
}