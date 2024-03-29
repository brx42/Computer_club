﻿using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Domain.Repositories.BaseClubRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.ScheduleAction.Create;

public class CreateSchedule : EndpointBaseAsync
    .WithRequest<CreateScheduleCommand>
    .WithActionResult<CreateScheduleResult>
{
    private readonly IBaseClubRepository<Schedule> _service;
    private readonly IMapper _mapper;

    public CreateSchedule(IBaseClubRepository<Schedule> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPost("api/clubs/schedules")]
    [SwaggerOperation(
        Summary = "Schedule create",
        Description = "Schedule create",
        OperationId = "Schedule.Create",
        Tags = new[] { "SchedulesEndpoints" })
    ]
    public override async Task<ActionResult<CreateScheduleResult>> HandleAsync
        ([FromBody]CreateScheduleCommand request, CancellationToken token = default)
    {
        var schedule = _mapper.Map<Schedule>(request);
        var add = await _service.AddAsync(schedule, token);
        var result = _mapper.Map<CreateScheduleResult>(add);
        return Created("", result);
    }
}