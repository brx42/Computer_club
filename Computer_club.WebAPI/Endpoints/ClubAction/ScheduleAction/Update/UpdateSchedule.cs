﻿using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Domain.Repositories.BaseClubRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.ScheduleAction.Update;

public class UpdateSchedule : EndpointBaseAsync
    .WithRequest<UpdateScheduleCommand>
    .WithActionResult<UpdateScheduleResult>
{
    private readonly IBaseClubRepository<Schedule> _service;
    private readonly IMapper _mapper;

    public UpdateSchedule(IBaseClubRepository<Schedule> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPut("api/clubs/schedules")]
    [SwaggerOperation(
        Summary = "Schedules update",
        Description = "Schedules update",
        OperationId = "Schedules.Update",
        Tags = new[] { "SchedulesEndpoints" })
    ]
    public override async Task<ActionResult<UpdateScheduleResult>> HandleAsync
        ([FromBody]UpdateScheduleCommand request, CancellationToken token = default)
    {
        var find = await _service.GetByIdAsync(request.Id);
        if (find == null) return NotFound();
        _mapper.Map(request, find);
        await _service.UpdateAsync(find, token);
        var result = _mapper.Map<UpdateScheduleResult>(find);
        return Ok(result);
    }
}