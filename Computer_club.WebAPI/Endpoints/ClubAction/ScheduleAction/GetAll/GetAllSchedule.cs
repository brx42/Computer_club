using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Services.ClubServices.ScheduleService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.ScheduleAction.GetAll;

public class GetAllSchedule : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult
{
    private readonly IScheduleService<Schedule> _service;
    private readonly IMapper _mapper;

    public GetAllSchedule(IScheduleService<Schedule> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("api/clubs/schedules")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Schedule get all",
        Description = "Schedule get all",
        OperationId = "Schedule.GetAll",
        Tags = new[] { "SchedulesEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(CancellationToken token = default)
    {
        var result = await _service.GetAllAsync(token);
        var map = _mapper.Map<List<GetAllScheduleResult>>(result);
        return Ok(map);
    }
}