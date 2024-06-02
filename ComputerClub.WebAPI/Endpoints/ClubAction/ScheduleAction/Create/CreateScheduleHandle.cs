using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.ScheduleAction.Create;

public class CreateScheduleHandle : Endpoint<CreateScheduleRequest, CreateScheduleResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<Schedule> _service;

    public CreateScheduleHandle(IMapper mapper, IBaseClubRepository<Schedule> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Post("club/schedule");

        Summary(sum => { sum.Summary = "Schedule create"; });

        Options(opt => opt.WithTags("Schedule"));

        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(CreateScheduleRequest request, CancellationToken ct)
    {
        Schedule schedule = _mapper.Map<Schedule>(request);

        Schedule addedSchedule = await _service.AddAsync(schedule, ct);

        CreateScheduleResponse response = _mapper.Map<CreateScheduleResponse>(addedSchedule);

        await SendOkAsync(response, ct);
    }
}