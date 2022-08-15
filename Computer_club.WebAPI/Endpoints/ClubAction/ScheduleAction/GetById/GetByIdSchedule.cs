using Computer_club.Data.Models.ClubModels;
using Computer_club.Domain.Repositories.BaseClubRepository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.ScheduleAction.GetById;

public class GetByIdSchedule : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<GetByIdScheduleResult>
{
    private readonly IBaseClubRepository<Schedule> _service;
    private readonly IMapper _mapper;

    public GetByIdSchedule(IBaseClubRepository<Schedule> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("api/clubs/schedules/{id}")]
    [SwaggerOperation(
        Summary = "Schedule get",
        Description = "Schedule get",
        OperationId = "Schedule.GetById",
        Tags = new[] { "SchedulesEndpoints" })
    ]
    public override async Task<ActionResult<GetByIdScheduleResult>> HandleAsync(int id, CancellationToken token = default)
    {
        var result = await _service.GetByIdAsync(id);
        var map = _mapper.Map<GetByIdScheduleResult>(result);
        return Ok(map);
    }
}