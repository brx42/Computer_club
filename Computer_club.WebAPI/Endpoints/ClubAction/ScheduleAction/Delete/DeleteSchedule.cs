using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Domain.Repositories.BaseClubRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.ScheduleAction.Delete;

public class DeleteSchedule : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult
{
    private readonly IBaseClubRepository<Schedule> _service;

    public DeleteSchedule(IBaseClubRepository<Schedule> service)
    {
        _service = service;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpDelete("api/clubs/schedules/{id}")]
    [SwaggerOperation(
        Summary = "Schedule delete ",
        Description = "Schedule delete",
        OperationId = "Schedule.delete",
        Tags = new[] { "SchedulesEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(int id, CancellationToken token = default)
    {
        var find = await _service.GetByIdAsync(id);
        if (find == null) return NotFound();
        var result = _service.DeleteAsync(find, token);
        return Ok(result);
    }
}