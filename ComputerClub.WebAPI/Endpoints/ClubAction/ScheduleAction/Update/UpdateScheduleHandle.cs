using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.ScheduleAction.Update;

public class UpdateScheduleHandle : Endpoint<UpdateScheduleRequest, UpdateScheduleResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<Schedule> _service;

    public UpdateScheduleHandle(IMapper mapper, IBaseClubRepository<Schedule> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Put("club/schedule");

        Summary(sum => { sum.Summary = "Schedule update"; });

        Options(opt => opt.WithTags("Schedule"));

        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(UpdateScheduleRequest request, CancellationToken ct)
    {
        Schedule? findSchedule = await _service.GetByIdAsync(request.Id);

        if (findSchedule == null)
        {
            await SendErrorsAsync(404, ct);
        }

        _mapper.Map(request, findSchedule);

        await _service.UpdateAsync(findSchedule, ct);

        UpdateScheduleResponse response = _mapper.Map<UpdateScheduleResponse>(findSchedule);

        await SendOkAsync(response, ct);
    }
}