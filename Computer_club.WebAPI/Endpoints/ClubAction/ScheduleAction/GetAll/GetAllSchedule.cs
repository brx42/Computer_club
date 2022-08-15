using Computer_club.Data.Models.ClubModels;
using Computer_club.Domain.Options;
using Computer_club.Domain.Repositories.BaseClubRepository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.ScheduleAction.GetAll;

public class GetAllSchedule : EndpointBaseAsync
    .WithRequest<Pagination>
    .WithActionResult
{
    private readonly IBaseClubRepository<Schedule> _service;
    private readonly IMapper _mapper;

    public GetAllSchedule(IBaseClubRepository<Schedule> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("api/clubs/schedules")]
    [SwaggerOperation(
        Summary = "Schedule get all",
        Description = "Schedule get all",
        OperationId = "Schedule.GetAll",
        Tags = new[] { "SchedulesEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync([FromQuery]Pagination pagination, CancellationToken token = default)
    {
        var result = await _service.GetAllAsync(pagination, token);
        var map = _mapper.Map<List<GetAllScheduleResult>>(result);
        return Ok(map);
    }
}