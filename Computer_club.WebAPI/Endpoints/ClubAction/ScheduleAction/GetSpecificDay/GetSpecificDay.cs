using Computer_club.Data.Models.ClubModels;
using Computer_club.Domain.Services.ClubServices.ScheduleService;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.ScheduleAction.GetSpecificDay;

public class GetSpecificDay : EndpointBaseAsync
    .WithRequest<GetSpecificDayCommand>
    .WithActionResult
{
    private readonly IScheduleService<Schedule> _service;
    private readonly IMapper _mapper;

    public GetSpecificDay(IScheduleService<Schedule> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("api/clubs/schedules_specific_day")]
    [SwaggerOperation(
        Summary = "Schedule get",
        Description = "Schedule get",
        OperationId = "Schedule.GetSpecificDay",
        Tags = new[] { "SchedulesEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync
        ([FromQuery]GetSpecificDayCommand request, CancellationToken token = default)
    {
        var result = await _service.GetTheScheduleOfASpecificDayAsync(request.Day, request.GameClubId);
        var map = _mapper.Map<GetSpecificDayResult>(result);
        return Ok(map);
    }
}